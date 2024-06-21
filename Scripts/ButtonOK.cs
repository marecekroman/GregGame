using Godot;
using System;

public partial class ButtonOK : Button{
	private void _on_pressed() {
		GregCakeQuest.HideInfoArea();
	}
}
