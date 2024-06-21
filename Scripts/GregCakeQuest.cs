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
	private static TextureRect _infoRect;

	//private static AudioStreamPlayer2D _introAudioPlayer;
	private static VideoStreamPlayer _introPlayer;

	//  Game sound status
	private static bool _isSoundActive = true;

	// Cake images
	private static TextureRect _cakeRect;

	private static Area2D _gregSprite;
	private static Area2D _cakeSprite;
	private static Area2D _mouseSprite;


	// Called when the node enters the scene tree for the first time. CakeArea
	public override void _Ready() {
		// Game Score
		_labelGregCounter = GetNode<Label>("ScoreArea/labelGregCounter");
		_labelMouseCounter = GetNode<Label>("ScoreArea/labelMouseCounter");
		_progressBarCounter = GetNode<ProgressBar>("ScoreArea/ProgressBar");
		_cakeRect = GetNode<TextureRect>("CakeArea/PieceCake");

		// Game sprites
		_gregSprite = GetNode<Area2D>("GameArea/Greg");
		_cakeSprite = GetNode<Area2D>("GameArea/PieceCake");
		_mouseSprite = GetNode<Area2D>("GameArea/Mouse");

		// Info Area
		_infoRect = GetNode<TextureRect>("InfoArea");

		// Intro Area
		_introPlayer = GetNode<VideoStreamPlayer>("Intro");
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

	public static bool GetSoundStatus() {
		return _isSoundActive;
	}

	public static void SetSoundStatus(bool status) {
		_isSoundActive = status;
	}

	public static void HideInfoArea() {
		_infoRect.Visible = false;
	}

	public static void ShowInfoArea() {
		_infoRect.Visible = true;
	}

	public static void HideGregSprite() {
		_gregSprite.Visible = false;
	}

	public static void SwapGregSprite(bool flipH) {
		_gregSprite.GetNode<AnimatedSprite2D>("GregSprite").FlipH = flipH;
	}

	public static void AnimGregSprite(bool play) {
		if (play)
			_gregSprite.GetNode<AnimatedSprite2D>("GregSprite").Play();
		else
			_gregSprite.GetNode<AnimatedSprite2D>("GregSprite").Stop();
	}

	public static void MouseCatchGregPlayAudio() {
		_gregSprite.GetNode<AudioStreamPlayer2D>("MouseStoleCake").Playing = true;
	}

	public static void GregCatchCakePlayAudio() {
		_cakeSprite.GetNode<AudioStreamPlayer2D>("GregCatchAudio").Playing = true;
	}


	public static void ShowGregSprite() {
		_gregSprite.Visible = true;
	}

	public static void HideCakeSprite() {
		_cakeSprite.Visible = false;
	}

	public static void ShowCakeSprite() {
		_cakeSprite.Visible = true;
	}

	public static void HideMouseSprite() {
		_mouseSprite.Visible = false;
	}

	public static void ShowMouseSprite() {
		_mouseSprite.Visible = true;
	}

	public static void HideAllSprites() {
		HideGregSprite();
		HideCakeSprite();
		HideMouseSprite();
	}

	public static void ShowAllSprites() {
		ShowGregSprite();
		ShowCakeSprite();
		ShowMouseSprite();
	}

	public static VideoStreamPlayer GetIntro() {
		return _introPlayer;
	}
	/*public static AudioStreamPlayer2D GetAudioIntro() {
		return _introAudioPlayer;
	}*/
}
