using Godot;

namespace CSGameTemplate.globals;

public partial class UiManager : Node
{
	private CanvasLayer _mainMenu;
	
	public override void _Ready()
	{
		_mainMenu = GetNode<CanvasLayer>("%MainMenu");

		Events.Instance.LifecycleStartGameRequested += OnLifecycleStartGameRequested;
	}

	private void OnLifecycleStartGameRequested()
	{
		_mainMenu.Hide();
	}
	
	// Define singleton logic
	public static UiManager Instance { get; private set; }
	public override void _EnterTree()
	{
		if (Instance != null) QueueFree(); // The Singleton is already loaded, kill this instance
		Instance = this;
	}
}