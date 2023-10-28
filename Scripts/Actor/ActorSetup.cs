using Godot;
using System;

public partial class ActorSetup : Resource {
    [Export] 
    public float speed = 64.0f;
    [Export]
    public float fallSpeed = 512.0f;
    [Export]
    public float friction = 20.0f;
	[Export]
	public float gravity = 1000f;
    [Export]
	public float jumpForce = -256f;

}
