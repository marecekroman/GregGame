using Godot;
using System;

public partial class BackgroundAudio : AudioStreamPlayer{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Playing = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		// Play the background music only when the game is running and the sound is active
		if (GregCakeQuest.IsGameRunning() == false || !GregCakeQuest.GetSoundStatus()) {
			Playing = false;
			return;
		}

		if (!Playing)
			Playing = true;
	}
}
