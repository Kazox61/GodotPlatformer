
using Godot;

public class ActorStateWalk: StateBase {
    public ActorStateWalk(ActorPlayer actorPlayer) : base(actorPlayer) {

    }

    public override void OnEnter() {
        _actorPlayer._hasMoved = true;
    }

    public override void OnPhysicsUpdate(double delta) {
        var targetVelocity = _actorPlayer.InputDirection * _actorPlayer.actorSetup.speed;
		var isStanding = _actorPlayer.movement.PhysicsMove(targetVelocity, _actorPlayer.actorSetup.friction, delta);

        if (!_actorPlayer.IsPositionOnGround) {
            _actorPlayer.stateMachine.TryEnterState(_actorPlayer.actorStateFall);
            return;
        }

        if (Input.IsActionJustPressed("Jump")) {
            _actorPlayer.stateMachine.TryEnterState(_actorPlayer.actorStateJump);
            return;
        }

        if (!isStanding) {
            return;
        }

        _actorPlayer.stateMachine.TryEnterState(_actorPlayer.actorStateWalk);
    }

}