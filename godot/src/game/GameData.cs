namespace ankitaiso.game;

using Chickensoft.Introspection;
using Chickensoft.Serialization;
using GameDemo;
using MapData = map.MapData;
using PlayerCameraData = player_camera.PlayerCameraData;
using PlayerData = player.PlayerData;

[Meta, Id("game_data")]
public partial record GameData {
  [Save("map_data")]
  public required MapData MapData { get; init; }

  [Save("player_data")]
  public required PlayerData PlayerData { get; init; }

  [Save("player_camera_data")]
  public required PlayerCameraData PlayerCameraData { get; init; }
}
