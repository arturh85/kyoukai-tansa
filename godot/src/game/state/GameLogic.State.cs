namespace ankitaiso.game.state;

using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;
using domain;
using GameDemo;

public partial class GameLogic {
  [Meta]
  public abstract partial record State : StateLogic<State> {
    protected State() {
      OnAttach(() => {
        var gameRepo = Get<IGameRepo>();
        gameRepo.IsMouseCaptured.Sync += OnIsMouseCaptured;
        gameRepo.IsPaused.Sync += OnIsPaused;
      });

      OnDetach(() => {
        var gameRepo = Get<IGameRepo>();
        gameRepo.IsMouseCaptured.Sync -= OnIsMouseCaptured;
        gameRepo.IsPaused.Sync -= OnIsPaused;
      });
    }

    public void OnIsMouseCaptured(bool isMouseCaptured) =>
      Output(new Output.CaptureMouse(isMouseCaptured));

    public void OnIsPaused(bool isPaused) =>
      Output(new Output.SetPauseMode(isPaused));
  }
}
