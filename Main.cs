using Godot;
using System;

public partial class Main : Control
{
	private Button _buttonUp;
	private Button _buttonRight;
	private Button _buttonDown;
	private Button _buttonLeft;
	private Button _resetButton;
	private Timer _mainTimer;
	private Timer _mouseTimer;
	private Random _random = new Random();

	private Texture2D _playerTexture, _emptyPlateTexture, _foodTexture, _plateTexture, _sliceOneTexture, _sliceTwoTexture, _sliceThreeTexture, _sliceFourTexture, _sliceFiveTexture, _sliceSixTexture, _sliceSevenTexture, _fullCakeTexture, _victoryTexture, _lossTexture, _mouseTexture, _flowerOneTexture, _flowerTwoTexture, _stoneTwoTexture, _stoneOneTexture;

	private TextureRect _cakeDisplay;
	private TextureButton _buttonW, _buttonA, _buttonS, _buttonD;

	private int _foodX = 2;
	private int _foodY = 2;
	private int _mouseDataX, _mouseDataY;
	private int _mouseX = 5;
	private int _mouseY = 5;
	private int _playerX = 0;
	private int _playerY = 0;
	private int _gridWidth = 1;
	private int _gridHeight = 1;
	private int _collectedFoodCount = 0;
	private bool _isGameFinished = false;

	private int _maxWidth = 0;
	private int _maxHeight = 0;
	private const int GridStepsWidth = 10;
	private const int GridStepsHeight = 10;

	private int _stepWidth = 0;
	private int _stepHeight = 0;

	private Texture2D[] _cakeTextures;

	public override void _Ready()
	{
		InitializeNodes();
		ConnectSignals();
		StartTimers();
		LoadTextures();
		UpdateCakeDisplay(0);  // Starting with an empty plate
	}

	private void InitializeNodes()
	{
		_buttonUp = GetNode<Button>("BtnUp");
		_buttonRight = GetNode<Button>("BtnDown");
		_buttonDown = GetNode<Button>("BtnRight");
		_buttonLeft = GetNode<Button>("BtnLeft");
		_resetButton = GetNode<Button>("BtnReset");
		_mainTimer = GetNode<Timer>("MainTimer");
		_mouseTimer = GetNode<Timer>("MouseTimer");

		_cakeDisplay = GetNode<TextureRect>("CakeDisplay");
		_buttonW = GetNode<TextureButton>("ButtonW");
		_buttonA = GetNode<TextureButton>("ButtonA");
		_buttonS = GetNode<TextureButton>("ButtonS");
		_buttonD = GetNode<TextureButton>("ButtonD");
	}

	private void ConnectSignals()
	{
		_buttonUp.Connect("pressed", new Callable(this, nameof(OnButtonUpPressed)));
		_buttonRight.Connect("pressed", new Callable(this, nameof(OnButtonRightPressed)));
		_buttonDown.Connect("pressed", new Callable(this, nameof(OnButtonDownPressed)));
		_buttonLeft.Connect("pressed", new Callable(this, nameof(OnButtonLeftPressed)));
		_resetButton.Connect("pressed", new Callable(this, nameof(OnResetButtonPressed)));

		_mainTimer.Connect("timeout", new Callable(this, nameof(OnMainTimerTimeout)));
		_mouseTimer.Connect("timeout", new Callable(this, nameof(OnMouseTimerTimeout)));
	}

	private void StartTimers()
	{
		_mainTimer.Start(1.0f);
		_mouseTimer.Start(0.15f);
	}

	private void LoadTextures()
	{
		_playerTexture = GD.Load<Texture2D>("res://resources/spriteone.png");
		_emptyPlateTexture = GD.Load<Texture2D>("res://resources/plateEmpty.png");
		_foodTexture = GD.Load<Texture2D>("res://resources/food.png");
		_plateTexture = GD.Load<Texture2D>("res://resources/plate.png");
		_sliceOneTexture = GD.Load<Texture2D>("res://resources/sliceOne.png");
		_sliceTwoTexture = GD.Load<Texture2D>("res://resources/sliceTwo.png");
		_sliceThreeTexture = GD.Load<Texture2D>("res://resources/sliceThree.png");
		_sliceFourTexture = GD.Load<Texture2D>("res://resources/sliceFour.png");
		_sliceFiveTexture = GD.Load<Texture2D>("res://resources/sliceFive.png");
		_sliceSixTexture = GD.Load<Texture2D>("res://resources/sliceSix.png");
		_sliceSevenTexture = GD.Load<Texture2D>("res://resources/sliceSeven.png");
		_fullCakeTexture = GD.Load<Texture2D>("res://resources/fullCake.png");
		_victoryTexture = GD.Load<Texture2D>("res://resources/uWin.png");
		_lossTexture = GD.Load<Texture2D>("res://resources/uLose.png");
		_mouseTexture = GD.Load<Texture2D>("res://resources/mouse.png");
		_flowerOneTexture = GD.Load<Texture2D>("res://resources/flowerone.png");
		_flowerTwoTexture = GD.Load<Texture2D>("res://resources/flowertwo.png");
		_stoneTwoTexture = GD.Load<Texture2D>("res://resources/stonetwo.png");
		_stoneOneTexture = GD.Load<Texture2D>("res://resources/stoneone.png");

		_cakeTextures = new Texture2D[]
		{
			GD.Load<Texture2D>("res://resources/plateEmpty.png"),
			GD.Load<Texture2D>("res://resources/sliceOne.png"),
			GD.Load<Texture2D>("res://resources/sliceTwo.png"),
			GD.Load<Texture2D>("res://resources/sliceThree.png"),
			GD.Load<Texture2D>("res://resources/sliceFour.png"),
			GD.Load<Texture2D>("res://resources/sliceFive.png"),
			GD.Load<Texture2D>("res://resources/sliceSix.png"),
			GD.Load<Texture2D>("res://resources/sliceSeven.png"),
			GD.Load<Texture2D>("res://resources/fullCake.png")
		};

		_buttonW.TextureNormal = GD.Load<Texture2D>("res://resources/button_w.png");
		_buttonA.TextureNormal = GD.Load<Texture2D>("res://resources/button_a.png");
		_buttonS.TextureNormal = GD.Load<Texture2D>("res://resources/button_s.png");
		_buttonD.TextureNormal = GD.Load<Texture2D>("res://resources/button_d.png");
	}

	public override void _Process(double delta)
	{
		QueueRedraw();
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey eventKey && eventKey.Pressed && !_isGameFinished)
		{
			HandleKeyPress(eventKey.Keycode);
		}
	}

	private void HandleKeyPress(Key key)
	{
		switch (key)
		{
			case Key.W:
				OnButtonUpPressed();
				break;
			case Key.S:
				OnButtonDownPressed();
				break;
			case Key.A:
				OnButtonLeftPressed();
				break;
			case Key.D:
				OnButtonRightPressed();
				break;
		}
	}

	public override void _Draw()
	{
		DrawGrid();
		DrawImages();
		CheckCollisions();
	}

	private void DrawGrid()
	{
		var size = GetViewportRect().Size;
		_maxWidth = (int)size.X;
		_maxHeight = (int)size.Y;

		_stepWidth = _maxWidth / GridStepsWidth;
		_stepHeight = _maxHeight / GridStepsHeight;

		_gridWidth = _stepWidth;
		_gridHeight = _stepHeight;

		for (int i = 1; i < GridStepsWidth; i++)
		{
			DrawLine(new Vector2(i * _stepWidth, 0), new Vector2(i * _stepWidth, _maxHeight), Colors.Black);
		}

		for (int i = 1; i < GridStepsHeight; i++)
		{
			DrawLine(new Vector2(0, i * _stepHeight), new Vector2(_maxWidth, i * _stepHeight), Colors.Black);
		}
	}

	private void DrawImages()
	{
		DrawTexture(_flowerOneTexture, new Vector2(0 * _stepWidth, 0 * _stepHeight));
		DrawTexture(_flowerOneTexture, new Vector2(7 * _stepWidth, 5 * _stepHeight));
		DrawTexture(_flowerOneTexture, new Vector2(1 * _stepWidth, 3 * _stepHeight));
		DrawTexture(_flowerOneTexture, new Vector2(1 * _stepWidth, 9 * _stepHeight));

		DrawTexture(_flowerTwoTexture, new Vector2(6 * _stepWidth, 3 * _stepHeight));
		DrawTexture(_flowerTwoTexture, new Vector2(4 * _stepWidth, 5 * _stepHeight));

		DrawTexture(_stoneTwoTexture, new Vector2(5 * _stepWidth, 0 * _stepHeight));
		DrawTexture(_stoneOneTexture, new Vector2(7 * _stepWidth, 8 * _stepHeight));

		DrawTexture(_foodTexture, new Vector2(_foodX * _stepWidth, _foodY * _stepHeight));
		DrawTexture(_playerTexture, new Vector2(_playerX * _stepWidth, _playerY * _stepHeight));
		DrawTexture(_mouseTexture, new Vector2(_mouseX * _stepWidth, _mouseY * _stepHeight));
	}

	private void CheckCollisions()
	{
		CheckFoodCollision();
		CheckVictoryCondition();
		CheckLossCondition();
		CheckMouseCollision();
	}

	private void CheckFoodCollision()
	{
		if (_foodX == _playerX && _foodY == _playerY)
		{
			_collectedFoodCount++;
			UpdateCakeDisplay(_collectedFoodCount);
			_mainTimer.Stop();
			_foodX = _random.Next(0, 9);
			_foodY = _random.Next(0, 9);
			_mainTimer.Start();
			QueueRedraw();
		}
	}

	private void UpdateCakeDisplay(int cakeLevel)
	{
		_cakeDisplay.Texture = _cakeTextures[Math.Min(cakeLevel, _cakeTextures.Length - 1)];
	}

	private void CheckVictoryCondition()
	{
		if (_collectedFoodCount == 8)
		{
			DrawTexture(_victoryTexture, new Vector2(0, 0));
			_isGameFinished = true;
			_resetButton.Visible = true;
		}
	}

	private void CheckLossCondition()
	{
		if (_collectedFoodCount < 0)
		{
			_mouseX = 10;
			_mouseY = 10;
			_mouseTimer.Stop();
			_mainTimer.Stop();
			DrawTexture(_lossTexture, new Vector2(0, 0));
			_isGameFinished = true;
			_resetButton.Visible = true;
		}
	}

	private void CheckMouseCollision()
	{
		if (_mouseX == _playerX && _mouseY == _playerY)
		{
			_collectedFoodCount--;
			UpdateCakeDisplay(_collectedFoodCount);
			_mouseTimer.Stop();
			_mouseX = _random.Next(0, 9);
			_mouseY = _random.Next(0, 9);
			_mouseTimer.Start();
			QueueRedraw();
		}
	}

	private void OnMainTimerTimeout()
	{
		_foodX = _random.Next(0, 9);
		_foodY = _random.Next(0, 9);
		QueueRedraw();
	}

	private void OnButtonUpPressed()
	{
		if (!_isGameFinished)
		{
			_playerY = Math.Max(0, _playerY - 1);
			QueueRedraw();
		}
	}

	private void OnButtonRightPressed()
	{
		if (!_isGameFinished)
		{
			_playerX = Math.Min(9, _playerX + 1);
			QueueRedraw();
		}
	}

	private void OnButtonDownPressed()
	{
		if (!_isGameFinished)
		{
			_playerY = Math.Min(9, _playerY + 1);
			QueueRedraw();
		}
	}

	private void OnButtonLeftPressed()
	{
		if (!_isGameFinished)
		{
			_playerX = Math.Max(0, _playerX - 1);
			QueueRedraw();
		}
	}

	private void OnMouseTimerTimeout()
	{
		if (!_isGameFinished)
		{
			MoveMouseRandomly();
			QueueRedraw();
		}
		else
		{
			EndGame();
		}
	}

	private void MoveMouseRandomly()
	{
		_mouseDataX = _random.Next(0, 4);
		_mouseDataY = _random.Next(0, 4);

		switch (_mouseDataX)
		{
			case 0:
				_mouseX = Math.Max(0, _mouseX - 1);
				break;
			case 1:
				_mouseX = Math.Min(9, _mouseX + 1);
				break;
			case 2:
				_mouseY = Math.Min(9, _mouseY + 1);
				break;
			case 3:
				_mouseY = Math.Max(0, _mouseY - 1);
				break;
		}
	}

	private void EndGame()
	{
		_mouseX = 10;
		_mouseY = 10;
		_mouseTimer.Stop();
		_mainTimer.Stop();
	}

	private void OnResetButtonPressed()
	{
		ResetGame();
	}

	private void ResetGame()
	{
		_foodX = 2;
		_foodY = 2;
		_mouseX = 5;
		_mouseY = 5;
		_playerX = 0;
		_playerY = 0;
		_gridWidth = 1;
		_gridHeight = 1;
		_collectedFoodCount = 0;
		_isGameFinished = false;
		_mouseTimer.Start();
		UpdateCakeDisplay(0);  // Reset to full cake
		QueueRedraw();
		_resetButton.Visible = false;
	}
}
