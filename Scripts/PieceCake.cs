using Godot;
using System;

public partial class PieceCake : Area2D{
    private const double spawnTimer = 2.0f;

    private Control gameArea;
    private Node2D gregCakeQuest;
    private double speed = spawnTimer;
    private RandomNumberGenerator rndGenerator = new RandomNumberGenerator();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        gameArea = GetNode<Control>("/root/GregCakeQuest/GameArea");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
        if (GregCakeQuest.IsGameRunning() == false)
            return;

        if (speed < 0.0f) {
            Visible = true;
            var deltaX = rndGenerator.RandiRange(0, 9);
            var deltaY = rndGenerator.RandiRange(0, 9);

            Position = new Vector2(deltaX * 70.0f, deltaY * 70.0f);
            speed = spawnTimer;
        }

        speed -= delta;
    }

    // Called when the node enters the area.
    private void _on_area_entered(Area2D area) {
        if (area is Mouse mouse) {
            GregCakeQuest.MouseCatchGregPlayAudio();
            mouse.Reset();
            speed = spawnTimer;
            Visible = false;
            GregCakeQuest.UpdateMouseCounter();
        }

        // Greg collect piece of cake
        if (area is Greg greg) {
            GregCakeQuest.GregCatchCakePlayAudio();
            Visible = false;
            GregCakeQuest.UpdateGregCounter(1);
        }
    }
}