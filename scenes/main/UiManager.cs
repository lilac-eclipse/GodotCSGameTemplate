using Godot;
using LilacRPG.globals;

namespace LilacRPG.scenes.main;

public partial class UiManager : Node
{
	private CanvasLayer _mainMenu;
	public override void _Ready()
	{
		_mainMenu = GetNode<CanvasLayer>("%MainMenu");

		Events.Instance.LifecycleStartGame += OnLifecycleStartGame;
		Events.Instance.LifecycleEnterWorld += OnLifecycleEnterWorld;
	}

	private void OnLifecycleStartGame()
	{
		_mainMenu.Show();
	}

	private void OnLifecycleEnterWorld()
	{
		_mainMenu.Hide();
	}
}