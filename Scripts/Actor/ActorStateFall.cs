
using Godot;

public class ActorStateFall: StateBase {
    public ActorStateFall(ActorPlayer actorPlayer) : base(actorPlayer) {

    }

    public override void OnPhysicsUpdate(double delta) {
        _actorPlayer.movement.PhysicsMove(Vector2.Down * 512f, 20, delta);
		_actorPlayer.ZIndex = -2;
    }

}