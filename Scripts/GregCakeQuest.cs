using Godot;

public partial class GregCakeQuest : Node2D{
	// Game score
	private static Label _labelGregCounter;
	private static Label _labelMouseCounter;
	private static ProgressBar _progressBarCounter;
	private static int _gregCounter = 0;
	private static int _mouseCounter = 0;
	public static int MaxGregCakes = 8;
	public static int MaxMouseCakes = 8;

	//  Game status
	private static bool _isGameRunning = true;

	// Cake images
	private static TextureRect _cakeRect;


	// Called when the node enters the scene tree for the first time. CakeArea
	public override void _Ready() {
		// Game Score
		_labelGregCounter = GetNode<Label>("ScoreArea/labelGregCounter");
		_labelMouseCounter = GetNode<Label>("ScoreArea/labelMouseCounter");
		_progressBarCounter = GetNode<ProgressBar>("ScoreArea/ProgressBar");
		_cakeRect = GetNode<TextureRect>("CakeArea/PieceCake");
	}

	public static bool IsGameRunning() {
		return _isGameRunning;
	}

	public static void SetGameRunning(bool value) {
		_isGameRunning = value;
	}

	public static void UpdateGregCounter(int direction) {
		if (direction == 1) {
			_gregCounter += 1;
		}
		else {
			if (_gregCounter > 0)
				_gregCounter -= 1;
		}

		_progressBarCounter.Value = _gregCounter;
		_labelGregCounter.Text = $"{_gregCounter}";
		SetCakeImage();
		if (_gregCounter >= MaxGregCakes)
			SetGameRunning(false);
	}

	public static void ResetGregCounter() {
		_gregCounter = 0;
		_labelGregCounter.Text = $"{_gregCounter}";
	}

	public static int GetGregCounter() {
		return _gregCounter;
	}

	public static void UpdateMouseCounter() {
		_mouseCounter += 1;
		_labelMouseCounter.Text = $"{_mouseCounter}";
		if (_mouseCounter >= MaxMouseCakes)
			SetGameRunning(false);
	}

	public static void ResetMouseCounter() {
		_mouseCounter = 0;
		_labelMouseCounter.Text = $"{_mouseCounter}";
	}

	public static int GetMouseCounter() {
		return _mouseCounter;
	}

	public static void SetCakeImage() {
		var texture = GD.Load<Texture2D>($"res://Assets/images/slice_{_gregCounter}.png");
		_cakeRect.Texture = texture;
	}
}
