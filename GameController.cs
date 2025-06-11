using Godot;
using System;

public partial class GameController : Node2D
{
	[Signal] public delegate void LifeUpdateEventHandler(int PlayerLifes);
	[Signal] public delegate void TimerUpdateEventHandler(int timerRest);
	[Export] private int PlayerLifes = 3;
	[Export] private int TimerRest = 60;
	
	private string FinishScene = "res://UI/scene_finish.tscn";
	private bool PlayerOver = false;
	
	public void GameOver() {
		PlayerOver = true;
		GetTree().ChangeSceneToFile(FinishScene);
	}
	
	public void onGameVictory(Node body) {
		GD.Print("GANASTEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
		SceneFinish FinishSceneInstance = (SceneFinish)GD.Load<PackedScene>(FinishScene).Instantiate();
		FinishSceneInstance.setTitle("Has ganado");
		AddChild(FinishSceneInstance);
	}
	
	public void onPlayerHit() {
		if (PlayerLifes > 1) {
			PlayerLifes -= 1;
		} else {
			GameOver();
		}
		EmitSignal("LifeUpdate", PlayerLifes);
	}
	
	public void onPlayerFail() {
		PlayerLifes = 0;
		GameOver();
		EmitSignal("LifeUpdate", PlayerLifes);
	}
	
	public void onTimerTimeout() {
		if (TimerRest > 1 && PlayerLifes != 0) {
			TimerRest -= 1;
		} else if (!PlayerOver) { 
			GameOver();
		}
		EmitSignal("TimerUpdate", TimerRest);
	}
}
