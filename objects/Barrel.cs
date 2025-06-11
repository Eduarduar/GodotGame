using Godot;
using System;

public partial class Barrel : RigidBody2D {
	
	[Export] public int destroy_bottom = 2918;
	
	private bool DamageDone = false;
	private Texture2D BarrilUsadoTexture = GD.Load<Texture2D>("res://utils/figures/purple/purple_body_circle.png");
 
	public override void _Process(double delta) {
		if (Position.Y > destroy_bottom) {
			QueueFree();
		}
	}
	
	public void _on_body_entered(Node body) {
		if (body is Personaje personaje && !DamageDone) {
			Sprite2D textureBarril = GetNode<Sprite2D>("Texture");
			textureBarril.Texture = BarrilUsadoTexture;

			personaje.DamageReceived();
			DamageDone = true;
		}
	}

}
