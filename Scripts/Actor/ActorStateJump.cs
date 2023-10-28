using Godot;

public class ActorStateJump : StateBase {
	public float _currentVelocityY;
	public ActorStateJump(ActorPlayer actorPlayer) : base(actorPlayer) {

	}

	public override void OnEnter() {
		_currentVelocityY = _actorPlayer.actorSetup.jumpForce;
	}

	public override void OnPhysicsUpdate(double delta) {
		var targetVelocity = _actorPlayer.InputDirection * _actorPlayer.actorSetup.speed;
		var isStanding = _actorPlayer.movement.PhysicsMove(targetVelocity, _actorPlayer.actorSetup.friction, delta);

		_currentVelocityY += _actorPlayer.actorSetup.gravity * (float)delta;
		_actorPlayer.actorSprite.Position += Vector2.Down * _currentVelocityY * (float)delta;
		
		if (_actorPlayer.actorSprite.Position.Y < 0.0f) {
			return;
		}

		_actorPlayer.actorSprite.Position = Vector2.Zero;
		_actorPlayer.stateMachine.TryEnterState(_actorPlayer.actorStateStand);
	}
}
