using Godot;
using System;

public partial class Personaje : CharacterBody2D {
	
	private Sprite2D sprite;
	
	[Signal] public delegate void PlayerHitEventHandler();
	[Signal] public delegate void PlayerFailEventHandler();
	
	[Export] public int destroy_bottom = 2918;
	[Export] public float Gravity = 100f;
	[Export] public float JumpSpeed = 100f;	
	[Export] public float Speed = 100f;
	[Export] public float Deceleration = 100f;
	
	public override void _Ready() {
		sprite = GetNode<Sprite2D>("textura");
	}
	
	public override void _Process(double delta) {
		if (Position.Y > destroy_bottom) {
			QueueFree();
			EmitSignal("PlayerFail");
		}
	}

	public override void _PhysicsProcess(double delta) {
		float direction = Input.GetAxis("izquierda", "derecha");

		// Movimiento horizontal
		Velocity = new Vector2(Velocity.X + Speed * direction, Velocity.Y);

		// Voltear sprite según la dirección
		if (direction != 0) {
			sprite.Scale = new Vector2(Mathf.Sign(direction) * Mathf.Abs(sprite.Scale.X), sprite.Scale.Y);
		}

		// Desaceleración
		if (Velocity.X > 0) {
			Velocity = new Vector2(Velocity.X - Deceleration, Velocity.Y);
			if (Velocity.X < 0) Velocity = new Vector2(0, Velocity.Y);
		} else if (Velocity.X < 0) {
			Velocity = new Vector2(Velocity.X + Deceleration, Velocity.Y);
			if (Velocity.X > 0) Velocity = new Vector2(0, Velocity.Y);
		}

		// Gravedad
		if (!IsOnFloor()) {
			Velocity = new Vector2(Velocity.X, Velocity.Y + Gravity * (float)delta);
		}

		// Salto
		if (Input.IsActionJustPressed("saltar") && IsOnFloor()) {
			Velocity = new Vector2(Velocity.X, Velocity.Y - JumpSpeed);
		}

		MoveAndSlide();
	}
	
	public void DamageReceived(){
		GD.Print("Daño recivido");
		EmitSignal("PlayerHit");
	}
}
