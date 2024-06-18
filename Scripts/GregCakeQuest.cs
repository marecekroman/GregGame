using Godot;

public partial class GregCakeQuest : Node2D{
	public static Label LabelGregCounter;
	public static Label LabelMouseCounter;
	public static int GregCounter = 0;
	public static int MouseCounter = 0;

	// Called when the node enters the scene tree for the first time. CakeArea
	public override void _Ready() {
		LabelGregCounter = GetNode<Label>("CakeArea/labelGregCounter");
		LabelMouseCounter = GetNode<Label>("CakeArea/labelMouseCounter");
	}

	public static void UpdateGregCounter() {
		GregCounter += 1;
		LabelGregCounter.Text = $"{GregCounter}";
	}

	public static void ResetGregCounter() {
		GregCounter = 0;
		LabelGregCounter.Text = $"{GregCounter}";
	}

	public static void UpdateMouseCounter() {
		MouseCounter += 1;
		LabelMouseCounter.Text = $"{MouseCounter}";
	}

	public static void ResetMouseCounter() {
		MouseCounter = 0;
		LabelMouseCounter.Text = $"{MouseCounter}";
	}
}
