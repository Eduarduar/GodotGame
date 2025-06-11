using Godot;
using System;

public partial class Boss : Node2D
{
	private AnimationPlayer animationBoss;

	private PackedScene escenaBarril = GD.Load<PackedScene>("res://objects/barrel.tscn");

	public override void _Ready()
	{
		animationBoss = GetNode<AnimationPlayer>("AnimationBoss");
	}

	public void LaunchBarrel()
	{
		Node2D instanciaBarril = (Node2D)escenaBarril.Instantiate();
		Node2D hand = GetNode<Node2D>("PurpleBodySquare/PurpleHandOpen");

		instanciaBarril.Position = hand.Position;

		AddChild(instanciaBarril);
		
		animationBoss.Play("reposo");
	}
	
	public void OnTimerTimeout() {
		Timer trigger = GetNode<Timer>("TriggerBarril");
		animationBoss.Play("lanzar");
		
		trigger.WaitTime = (float)GD.RandRange(2.0, 5.0);
	}
}
