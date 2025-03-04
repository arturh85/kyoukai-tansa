using Enemy = kyoukaitansa.enemy.Enemy;

namespace kyoukaitansa.game_typing;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using app.domain;
using Chickensoft.AutoInject;
using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;
using domain;
using enemy_panel;
using game.state;
using Godot;
using state;

[Meta(typeof(IAutoNode))]
[SceneTree]
public partial class GameTyping : Node3D {
  public override void _Notification(int what) => this.Notify(what);

  public IGameTypingRepo GameTypingRepo { get; set; } = default!;
  public IGameTypingLogic GameTypingLogic { get; set; } = default!;

  public LogicBlock<GameTypingLogic.State>.IBinding GameTypingBinding { get; set; } = default!;

  public Vector3 PlayerPosition;
  public Vector3 SpawnPosition;

  private Enemy? activeEnemy;
  private const int MaxEnemyPanels = 4;
  public Stack<string> WordList = new();

  [Dependency] public IAppRepo AppRepo => this.DependOn<IAppRepo>();

  public void Setup() {
    GameTypingRepo = new GameTypingRepo();
    GameTypingLogic = new GameTypingLogic();
    GameTypingLogic.Set(GameTypingRepo);
    GameTypingBinding = GameTypingLogic.Bind();
    GameTypingBinding
      .Handle(
        (in GameTypingLogic.Output.StartGame _) => {
        });

    // Trigger the first state's OnEnter callbacks so our bindings run.
    // Keeps everything in sync from the moment we start!
    GameTypingLogic.Start();
    GD.Print("Game State Start");

    GameTypingLogic.Input(new GameLogic.Input.Initialize());

    this.Provide();
  }

  // Called when the node enters the scene tree for the first time.
  public override void _Ready() {
    GD.Print("GameTyping Ready");
    SetPaused(true);
    Setup();

    for (int i = 0; i < MaxEnemyPanels; i++) {
      var panel = EnemyPanel.Instantiate();
      panel.Hide();
      GuiControls.AddChild(panel);
    }
  }

  public void OnResolved() {
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta) {
    if (paused) return;
    var nearest = Enemy.GetNearestEnemies(PlayerPosition, EnemiesContainer, MaxEnemyPanels);

    var idx = 0;
    foreach (var child in _.GuiControls.GetChildren()) {
      if (child is EnemyPanel panel) {
        if (nearest.Count <= idx) {
          panel.Hide();
        }
        else {
          var enemy = nearest[idx];
          panel.UpdateGui(enemy);
        }

        idx += 1;
      }
    }
  }


  public bool paused = true;
  public bool game_started = false;


  public void StartGame() {
    LoadWordlist();
    game_started = true;
    SetPaused(false);
  }

  public void SetPaused(bool _paused) {
    if (!game_started) {
      return;
    }

    paused = _paused;
    if (_paused) {
      _.Timer.Stop();
    }
    else {
      _.Timer.Start();
    }
  }

  public override void _Input(InputEvent @event)
  {
    if (@event is InputEventKey keyEvent && keyEvent.Pressed)
    {
      if (activeEnemy != null) {
        activeEnemy.OnInput(keyEvent);
      }
      else {
        var s = OS.GetKeycodeString(keyEvent.Keycode);
        foreach (var enemy in EnemiesContainer.GetChildren().OfType<Enemy>()) {
          if (enemy.Moving && enemy.Prompt.ToUpper().StartsWith(s)) {
            activeEnemy = enemy;
            activeEnemy.OnInput(keyEvent);
            activeEnemy.OnDelete += _on_active_enemy_deleted;
            break;
          }
        }
      }
    }
  }

  public static void Shuffle<T>(IList<T> list)
  {
    int n = list.Count;
    while (n > 1) {
      n--;
      int k = Random.Shared.Next(n + 1);
      T value = list[k];
      list[k] = list[n];
      list[n] = value;
    }
  }

  public void LoadWordlist() {
    var scenario = AppRepo.GetActiveScenario();
    var content = scenario.ReadWordList();
    WordList.Clear();
    var words = new List<string>();
    var lines = Regex.Split(content, "\r\n|\r|\n");
    foreach (var line in lines) {
      words.Add(line.Split("|")[0]);
    }
    Shuffle(words);

    var options = AppRepo.GetActiveScenarioOptions();
    for (int i = 0; i < Math.Min(options.WordsPlayed, words.Count); i++) {
      WordList.Push(words[i]);
    }
    GD.Print("WordList Loaded");
  }


  public void SpawnEnemy() {
    if (EnemiesContainer.GetChildren().Count >= 5) {
      return;
    }

    const float spawnRadius = 5.0f;
    const float minDistanceBetweenEnemies = 2.0f;
    const int maxSpawnAttempts = 10;

    var rng = new RandomNumberGenerator();
    rng.Randomize();

    Vector3 spawnPosition = FindValidSpawnPosition3D(rng, spawnRadius, minDistanceBetweenEnemies, maxSpawnAttempts);
    var enemy = CreateEnemy3D(spawnPosition);
    EnemiesContainer.AddChild(enemy);
    // var start = Stopwatch.GetTimestamp();
    // GD.Print("Created Enemy " + enemy.Prompt + " in " + Stopwatch.GetElapsedTime(start).TotalMilliseconds + " ms");
  }

  private Vector3 FindValidSpawnPosition3D(RandomNumberGenerator rng, float radius, float minDistance,
    int maxAttempts) {
    var existingEnemies = Enumerable.Cast<Enemy>(EnemiesContainer.GetChildren()).ToList();

    for (int i = 0; i < maxAttempts; i++) {
      Vector3 candidatePosition = GenerateRandomPositionInArc(rng, SpawnPosition, radius, MathF.PI / 2);

      if (!IsPositionOccupied3D(candidatePosition, existingEnemies, minDistance)) {
        return candidatePosition;
      }
    }

    // Fallback to random position without collision check
    return GenerateRandomPositionInArc(rng, SpawnPosition, radius, MathF.PI / 2);
  }

  private Vector3 GenerateRandomPositionInArc(RandomNumberGenerator rng, Vector3 center, float radius,
    float arcAngleRadians) {
    // Calculate direction from player to the center point
    Vector3 toCenter = center - PlayerPosition;
    // Get the angle of this direction in the XZ plane (azimuth)
    float thetaCenter = Mathf.Atan2(toCenter.Z, toCenter.X);
    // Random angle within the arc around the center angle
    float randomAngle = rng.RandfRange(thetaCenter - arcAngleRadians / 2, thetaCenter + arcAngleRadians / 2);
    // Random distance from the player (0 to radius)
    float distance = toCenter.Length();

    // Calculate position in XZ plane around the player's position
    float x = PlayerPosition.X + distance * Mathf.Cos(randomAngle);
    float z = PlayerPosition.Z + distance * Mathf.Sin(randomAngle);

    // Keep Y coordinate same as the center's Y (or set to PlayerPosition.Y if needed)
    return new Vector3(x, center.Y, z);
  }

  private bool IsPositionOccupied3D(Vector3 position, List<Enemy> existingEnemies, float minDistance) {
    foreach (var enemy in existingEnemies) {
      if (enemy.Position.DistanceTo(position) < minDistance) {
        return true;
      }
    }

    return false;
  }

  private Enemy CreateEnemy3D(Vector3 position) {
    var enemy = Enemy.Instantiate(PopRandomWord(), PlayerPosition);
    enemy.Position = position;
    return enemy;
  }

  private string PopRandomWord() => WordList.Count > 0 ? WordList.Pop() : "empty";

  public void _on_timer_timeout() => SpawnEnemy();

  public void _on_active_enemy_deleted() => activeEnemy = null;
}
