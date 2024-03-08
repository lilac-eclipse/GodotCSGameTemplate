using Godot;

namespace CSGameTemplate.scenes.game;

public partial class Game : Control
{
	private Label _countLabel;
	private Button _incrButton;

	private int _count = 0;
	
	public override void _Ready()
	{
		_countLabel = GetNode<Label>("%CountLabel");
		_incrButton = GetNode<Button>("%IncrButton");
		
		_incrButton.Pressed += IncrButtonOnPressed;
		UpdateCountLabel();
	}

	private void IncrButtonOnPressed()
	{
		_count += 1;
		UpdateCountLabel();
	}

	private void UpdateCountLabel()
	{
		_countLabel.Text = "Count: " + _count;
	}
}