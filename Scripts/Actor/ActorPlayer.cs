using Godot;
using System;
using System.Collections.Generic;

public partial class ActorPlayer : CharacterBody2D {
	[Export]
	public ActorSetup actorSetup;
	[Export]
	public Sprite2D actorSprite;

	public Vector2 InputDirection => Input.GetVector("Left", "Right", "Up", "Down");
	public bool IsPositionOnGround => _touchingGround.Count > 0 || !_hasMoved;
	public bool _hasMoved = false;
	public List<PhysicsBody2D> _touchingGround = new List<PhysicsBody2D>();

	public Movement movement;
	public StateMachine stateMachine = new StateMachine();
	public ActorStateStand actorStateStand;
	public ActorStateWalk actorStateWalk;
	public ActorStateFall actorStateFall;
	public ActorStateJump actorStateJump;

    public override void _Ready() {
		actorStateStand = new ActorStateStand(this);
		actorStateWalk = new ActorStateWalk(this);
		actorStateFall = new ActorStateFall(this);
		actorStateJump = new ActorStateJump(this);

		stateMachine.TryEnterState(actorStateStand);

		movement = new Movement(this);
    }

    public override void _Process(double delta) {
        stateMachine.CurrentSate.OnUpdate(delta);
    }

    public override void _PhysicsProcess(double delta) {
		stateMachine.CurrentSate.OnPhysicsUpdate(delta);
	}

	public void _OnGroundEnter(PhysicsBody2D body) {
		_touchingGround.Add(body);
	}

	public void _OnGroundLeave(PhysicsBody2D body) {
		_touchingGround.Remove(body);
	}
}
