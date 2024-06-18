using Godot;
using System;

public partial class Greg : Area2D{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}

	private void _greg_area_entered(Area2D area) {
		// Player get hit from mouse
		if (area is Mouse mouse && (mouse.GetMouseMode() == 1 || mouse.GetMouseMode() == 0)) {
			mouse.Reset();
			GD.Print($"Mouse catch Geg: X = {Position.X}, Y = {Position.Y}");
		}
	}
}
