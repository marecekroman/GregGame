using Godot;
using System;
using System.Drawing;

public partial class mouse : Area2D
{
	private const double spawnTimer = 0.9f;
	private Control gameArea;
	private double speed = spawnTimer;
	private RandomNumberGenerator rndGenerator = new RandomNumberGenerator();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gameArea = GetNode<Control>("../GameArea");

		/*GD.Print($"Pozice GameArea: X = {gameArea.Position.X}, Y = {gameArea.Position.Y}");
		GD.Print($"Velikost GameArea: W = {gameArea.Size.X}, H = {gameArea.Size.Y}");
		GD.Print($"Pozice: X = {Position.X}, Y = {Position.Y}");*/
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (speed < 0.0f)
		{
			var deltaX = rndGenerator.RandfRange(0.0f, 9.0f);
			var deltaY = rndGenerator.RandfRange(0.0f, 9.0f);
			// GD.Print($"Pozice GameArea: X = {deltaX}, Y = {deltaY}");
			Position = new Vector2(deltaX * 70.0f, deltaY * 70.0f);
			speed = spawnTimer;
		}

		speed -= delta;
	}
}
