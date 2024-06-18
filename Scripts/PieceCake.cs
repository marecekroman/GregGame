using Godot;
using System;

public partial class PieceCake : Area2D{
	private const double spawnTimer = 2.0f;

	private Control gameArea;
	private double speed = spawnTimer;
	private RandomNumberGenerator rndGenerator = new RandomNumberGenerator();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		gameArea = GetNode<Control>("../GameArea");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		if (speed < 0.0f) {
			Visible = true;
			var deltaX = rndGenerator.RandfRange(0.0f, 9.0f);
			var deltaY = rndGenerator.RandfRange(0.0f, 9.0f);

			Position = new Vector2(deltaX * 70.0f, deltaY * 70.0f);
			speed = spawnTimer;
		}

		speed -= delta;
	}

	// Called when the node enters the area.
	private void _on_area_entered(Area2D area) {
		if (area is Mouse mouse && (mouse.GetMouseMode() == 2 || mouse.GetMouseMode() == 0)) {
			mouse.Reset();
			speed = spawnTimer;
			Visible = false;
			GD.Print($"Mouse Cake: X = {Position.X}, Y = {Position.Y}");
		}

		// Greg collect piece of cake
		if (area is Greg greg) {
			Visible = false;
			GD.Print($"Greg catch Cake: X = {greg.Position.X}, Y = {greg.Position.Y}");
		}
	}
}
