using Godot;
using System;

public partial class Camera2d : Camera2D {
	
	[Export]
	public Node2D ObjectToFollow;
	
	public override void _Process(double delta){
		if (ObjectToFollow != null){
			Position = ObjectToFollow.Position;
		}
	}

	public override void _PhysicsProcess(double delta){}
}
