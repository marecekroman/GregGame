using Godot;

public partial class Mouse : Area2D{
    private const double SpawnTimer = 1.0f;
    private const double MoveTimer = 0.6f;

    private double _speed = SpawnTimer;
    private double _moveTimer = 0;
    private int _countModeCycle;

    private Area2D _pieceCake;
    private Area2D _greg;

    private Vector2 _deltaMove;

    // 0 - hunting player, 1 - hunting cake
    private int _mouseMode;

    private RandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        _pieceCake = GetNode<Area2D>("../PieceCake");
        _greg = GetNode<Area2D>("../Greg");
        _mouseMode = _randomNumberGenerator.RandiRange(0, 1);
        _countModeCycle = _randomNumberGenerator.RandiRange(1, 4);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
        if (GregCakeQuest.IsGameRunning() == false)
            return;

        if (_countModeCycle < 0) {
            _mouseMode = _randomNumberGenerator.RandiRange(0, 1);
            _countModeCycle = _randomNumberGenerator.RandiRange(1, 4);
        }

        if (_mouseMode == 1) {
            _HuntingCake(delta);
        }
        else if (_mouseMode == 0) {
            _HuntingPlayer(delta);
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
        if (_greg.Visible && _moveTimer > MoveTimer) {
            Visible = true;
            _deltaMove = new Vector2(
                    _greg.Position.X - Position.X,
                    _greg.Position.Y - Position.Y)
                .Normalized();

            Position += _deltaMove * 70;
            _moveTimer = 0;
        }
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