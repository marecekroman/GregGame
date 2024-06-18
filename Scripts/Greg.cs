using Godot;
using System;
using System.Drawing;

public partial class Greg : Area2D{
    // Called when the node enters the scene tree for the first time.
    private Control _gameArea;
    private double _time = 0;
    private Vector2 _direction = new Vector2(0, 0);
    private Vector2 _newPosition = new Vector2(0, 0);
    private float _speed = 500;

    public override void _Ready() {
        _gameArea = GetNode<Control>("/root/GregCakeQuest/GameArea");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
        if (GregCakeQuest.IsGameRunning() == false)
            return;

        // Animation - add movement between two points
        var actualPosition = Position + _direction * (float)delta * _speed;

        if (actualPosition.X < 0 || actualPosition.Y < 0 || actualPosition.X >= _gameArea.Size.X - 70 ||
            actualPosition.Y >= _gameArea.Size.Y - 70)
            return;

        if (checkTileBoundary(_newPosition)) {
            Position = actualPosition;
        }
    }

    private bool checkTileBoundary(Vector2 target) {
        bool stop = true;
        // horizontal boundary
        if (_direction.X != 0) {
            if (_direction.X > 0) {
                if (Position.X >= target.X)
                    stop = false;
            }
            else {
                if (Position.X <= target.X)
                    stop = false;
            }
        }
        else if (_direction.Y != 0) {
            if (_direction.Y > 0) {
                if (Position.Y >= target.Y)
                    stop = false;
            }
            else {
                if (Position.Y <= target.Y)
                    stop = false;
            }
        }

        return stop;
    }

    public override void _Input(InputEvent @event) {
        if (GregCakeQuest.IsGameRunning() == false)
            return;

        if (@event.IsActionPressed("ui_left")) {
            if (Position.X > 0) {
                _newPosition = new Vector2(Position.X - 70, Position.Y);
                _direction = new Vector2(-1, 0);
            }
        }
        else if (@event.IsActionPressed("ui_right")) {
            if (Position.X < _gameArea.Size.X - 70) {
                _newPosition = new Vector2(Position.X + 70, Position.Y);
                _direction = new Vector2(1, 0);
            }
        }
        else if (@event.IsActionPressed("ui_up")) {
            if (Position.Y > 0) {
                _newPosition = new Vector2(Position.X, Position.Y - 70);
                _direction = new Vector2(0, -1);
            }
        }
        else if (@event.IsActionPressed("ui_down")) {
            if (Position.Y < _gameArea.Size.Y - 70) {
                _newPosition = new Vector2(Position.X, Position.Y + 70);
                _direction = new Vector2(0, 1);
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
            GregCakeQuest.UpdateGregCounter(0);
        }
    }
}