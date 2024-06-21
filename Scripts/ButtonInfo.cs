using Godot;
using System;

public partial class ButtonInfo : Button{
	private void _on_pressed() {
		GregCakeQuest.ShowInfoArea();
	}
}
