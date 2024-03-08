using CSGameTemplate.globals;
using Godot;

namespace CSGameTemplate.scenes.game;

public partial class Game : Control
{
	private GameState GameState => SaveDataWrapper.Instance.SaveData.GameState;
	
	private Label _countLabel;
	private Button _incrButton;
	
	public override void _Ready()
	{
		_countLabel = GetNode<Label>("%CountLabel");
		_incrButton = GetNode<Button>("%IncrButton");
		
		_incrButton.Pressed += IncrButtonOnPressed;
		UpdateCountLabel();
	}

	private void IncrButtonOnPressed()
	{
		GameState.Count += 1;
		UpdateCountLabel();
		SaveDataWrapper.Instance.Save(); // TODO move save logic elsewhere
	}

	private void UpdateCountLabel()
	{
		_countLabel.Text = "Count: " + GameState.Count;
	}
}