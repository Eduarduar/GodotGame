using Godot;
using System;
using System.Collections.Generic;

public partial class Interface : CanvasLayer
{
	private Texture2D HeartPurple = GD.Load<Texture2D>("res://utils/figures/tile_heart_morado.png");
	private Texture2D HeartEmpty = GD.Load<Texture2D>("res://utils/figures/tile_heart_empty.png");
	private Label LabelTimer;


	private List<TextureRect> _hearts = new List<TextureRect>();

	public override void _Ready()
	{
		LabelTimer = GetNode<Label>("CointainerTimer/LabelTimer");
		HBoxContainer corasContainer = GetNode<HBoxContainer>("Coras");

		if (corasContainer == null)
		{
			GD.PrintErr("No se encontró el nodo 'Coras'");
			return;
		}

		for (int i = 0; i < 3; i++)
		{
			TextureRect heart = new TextureRect();
			heart.Texture = HeartPurple;

			heart.CustomMinimumSize = new Vector2(32, 32);
			heart.StretchMode = TextureRect.StretchModeEnum.KeepAspectCentered;

			_hearts.Add(heart);
			corasContainer.AddChild(heart);
		}
	}

	public void onUpdateLifes(int PlayerLifes)
	{
		for (int i = 0; i < _hearts.Count; i++)
		{
			_hearts[i].Texture = i < PlayerLifes ? HeartPurple : HeartEmpty;
		}
	}
	
	public void onTimerUpdate(int TimerRest) {
		LabelTimer.Text = "Tiempo: " + TimerRest + " Seg.";
	}
}
