using Godot;
using System;

public partial class SceneFinish : CanvasLayer
{
	private string MainEsene = "res://main_esene.tscn";
	
	public void setTitle(string Message) {
		Label MessageLabel = GetNode<Label>("VBoxContainer/Label");
		MessageLabel.Text = Message;
	}
	
	public void onPressed() {
		GetTree().ChangeSceneToFile(MainEsene);
	}
}
