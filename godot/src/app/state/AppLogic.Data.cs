namespace ankitaiso.app.state;

public partial class AppLogic {
  public record Data {
    public bool ShouldLoadExistingGame { get; set; }
  }
}
