namespace ankitaiso.map.state;
public partial class MapLogic {
  public static class Input {
    public readonly record struct GameLoadedFromSaveFile(int NumCoinsCollected);
  }
}
