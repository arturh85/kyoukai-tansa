namespace ankitaiso.player.state;

using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;

public interface IPlayerLogic : ILogicBlock<PlayerLogic.State>;

[Meta, Id("player_logic")]
[LogicBlock(typeof(State), Diagram = true)]
public partial class PlayerLogic : LogicBlock<PlayerLogic.State>, IPlayerLogic {
  public override Transition GetInitialState() => To<PlayerLogic.State.Disabled>();
}
