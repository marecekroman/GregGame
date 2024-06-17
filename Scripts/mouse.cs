using Godot;
using System;
using System.Drawing;

public partial class mouse : Area2D
{
	private Vector2 _initialPosition;
	private Vector2 _mouseDirection;
	private Control _gameArea;
	private Control _mouseControl;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gameArea = GetNode<Control>("../GameArea");
		_mouseControl = GetNode<Control>("./TextureRect");

		GD.Print($"Pozice GameArea: X = {_gameArea.Position.X}, Y = {_gameArea.Position.Y}");
		GD.Print($"Velikost GameArea: W = {_gameArea.Size.X}, H = {_gameArea.Size.Y}");

		GD.Print($"Pozice: X = {Position.X}, Y = {Position.Y}");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Animate mouse movement
		if (Position > new Vector2(_gameArea.Size.X - _mouseControl.Size.X, _gameArea.Size.Y - _mouseControl.Size.Y))
		{
			Position += new Vector2(1.0f, 0.0f);
		}

		if (Position < new Vector2(0.0f, 0.0f))
		{
			Position += new Vector2(0.0f, 1.0f);
		}
		else
		{
		}
	}
}
