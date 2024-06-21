using Godot;
using System;

public partial class ButtonStartStop : Button{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		GregCakeQuest.SetGameRunning(false);
		Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		if (!GregCakeQuest.GetIntro().IsPlaying()) {
			Visible = true;
		}

		if (GregCakeQuest.IsGameRunning()) {
			Text = "Game Stop";
			return;
		}

		Text = "Game Start";
	}

	private void _on_pressed() {
		if (GregCakeQuest.IsGameRunning()) {
			GregCakeQuest.SetGameRunning(false);
			Text = "Game Start";
			GregCakeQuest.HideAllSprites();
			return;
		}

		Text = "Game Stop";
		GregCakeQuest.ResetGregCounter();
		GregCakeQuest.ResetMouseCounter();
		GregCakeQuest.SetGameRunning(true);

		GregCakeQuest.ShowAllSprites();
	}
}
