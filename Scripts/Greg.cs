using Godot;
using System;
using System.Drawing;

public partial class Greg : Area2D{
	// Called when the node enters the scene tree for the first time.
	private Control gameArea;
	private double _time = 0;
	private int _direction = 0;

	public override void _Ready() {
		gameArea = GetNode<Control>("../GameArea");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}

	public override void _Input(InputEvent @event) {
		if (@event.IsActionPressed("ui_left")) {
			GD.Print($"Greg move LEFT: X = {Position.X}, Y = {Position.Y}");
			if (Position.X > 0) {
				Position = new Vector2(Position.X - 70, Position.Y);
			}
		}
		else if (@event.IsActionPressed("ui_right")) {
			GD.Print($"Greg move RIGHT: X = {Position.X}, Y = {Position.Y}");
			if (Position.X < gameArea.Size.X - 70) {
				Position = new Vector2(Position.X + 70, Position.Y);
			}
		}
		else if (@event.IsActionPressed("ui_up")) {
			GD.Print($"Greg move UP: X = {Position.X}, Y = {Position.Y}");
			if (Position.Y > 0) {
				Position = new Vector2(Position.X, Position.Y - 70);
			}
		}
		else if (@event.IsActionPressed("ui_down")) {
			GD.Print($"Greg move DOWN: X = {Position.X}, Y = {Position.Y}");
			if (Position.Y < gameArea.Size.Y - 70) {
				Position = new Vector2(Position.X, Position.Y + 70);
			}
		}
	}

	public void Reset() {
		Position = new Vector2(0, 0);
	}

	private void _greg_area_entered(Area2D area) {
		// Player get hit from mouse in any mode
		if (area is Mouse mouse) {
			mouse.Reset();
			GD.Print($"Mouse catch Geg: X = {Position.X}, Y = {Position.Y}");
			Reset();
		}
	}
}
