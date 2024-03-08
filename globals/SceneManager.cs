using Godot;

namespace CSGameTemplate.globals;

public partial class SceneManager : Node
{
    private Control _game;
    
    public override void _Ready()
    {
        _game = GetNode<Control>("%Game");

        Events.Instance.LifecycleStartGameRequested += InstanceOnLifecycleStartGameRequested;
    }

    private void InstanceOnLifecycleStartGameRequested()
    {
        _game.Show();
    }

    // Define singleton logic
    public static SceneManager Instance { get; private set; }
    public override void _EnterTree()
    {
        if (Instance != null) QueueFree(); // The Singleton is already loaded, kill this instance
        Instance = this;
    }
}