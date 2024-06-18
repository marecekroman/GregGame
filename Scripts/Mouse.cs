using Godot;

public partial class Mouse : Area2D{
    private const double SpawnTimer = 1.0f;
    private const double MoveTimer = 0.6f;

    private double _speed = SpawnTimer;
    private double _moveTimer = 0;
    private int _countModeCycle = 5;

    private Area2D _pieceCake;
    private Area2D _greg;

    private Vector2 _deltaMove;

    // 0 - random spawn, 1 - hunting player, 2 - hunting cake
    private int _mouseMode = 2;

    private RandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        _pieceCake = GetNode<Area2D>("../PieceCake");
        _greg = GetNode<Area2D>("../Greg");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
        if (GregCakeQuest.IsGameRunning() == false)
            return;

        if (_countModeCycle < 0) {
            _mouseMode += 1;
            if (_mouseMode > 2)
                _mouseMode = 0;
            GD.Print($"Mouse mode selected: {_mouseMode}");
            if (_mouseMode != 0)
                _countModeCycle = _randomNumberGenerator.RandiRange(1, 4);
            else {
                _countModeCycle = 1;
            }

            GD.Print($"Mouse mode count : {_countModeCycle}");
        }

        if (_mouseMode == 2) {
            _HuntingCake(delta);
        }
        else if (_mouseMode == 1) {
            _HuntingPlayer(delta);
        }
        else {
            _RandomSpawn(delta);
        }
    }

    public int GetMouseMode() {
        return _mouseMode;
    }

    //Mouse hunting cake
    private void _HuntingCake(double delta) {
        _moveTimer += delta;
        if (_pieceCake.Visible && _moveTimer > MoveTimer) {
            Visible = true;
            _deltaMove = new Vector2(
                    _pieceCake.Position.X - Position.X,
                    _pieceCake.Position.Y - Position.Y)
                .Normalized();

            Position += _deltaMove * 70;
            _moveTimer = 0;
        }
    }

    // Mouse hunting player
    private void _HuntingPlayer(double delta) {
        _moveTimer += delta;
        if (_pieceCake.Visible && _greg.Visible && _moveTimer > MoveTimer) {
            Visible = true;
            _deltaMove = new Vector2(
                    _greg.Position.X - Position.X,
                    _greg.Position.Y - Position.Y)
                .Normalized();

            Position += _deltaMove * 70;
            _moveTimer = 0;
        }
    }

    // Mouse random spawn
    private void _RandomSpawn(double delta) {
        if (_speed < 0.0f) {
            Visible = true;
            var deltaX = _randomNumberGenerator.RandiRange(0, 9);
            var deltaY = _randomNumberGenerator.RandiRange(0, 9);

            Position = new Vector2(deltaX * 70.0f, deltaY * 70.0f);
            _speed = SpawnTimer;
        }

        _speed -= delta;
    }

    // Called when the node enters the area.
    public void Reset() {
        Visible = false;
        _countModeCycle--;
        // set new random position after reset
        var deltaX = _randomNumberGenerator.RandfRange(0.0f, 9.0f);
        var deltaY = _randomNumberGenerator.RandfRange(0.0f, 9.0f);
        Position = new Vector2(deltaX * 70.0f, deltaY * 70.0f);
    }
}