using Godot;
using System;

public partial class ButtonSoundOff : Button{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		// default sound status is true
		GregCakeQuest.SetSoundStatus(true);
	}

	private void _on_pressed() {
		if (GregCakeQuest.GetSoundStatus()) {
			GregCakeQuest.SetSoundStatus(false);
			var texture = GD.Load<Texture2D>($"res://Assets/images/noun-mute-border.svg");
			Icon = texture;
		}
		else {
			GregCakeQuest.SetSoundStatus(true);
			var texture = GD.Load<Texture2D>($"res://Assets/images/noun-speaker-border.svg");
			Icon = texture;
		}
	}
}
