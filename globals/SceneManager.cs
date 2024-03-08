using Godot;

namespace CSGameTemplate.globals;

public partial class SceneManager : Node
{
    // private Node2D _overworld;
    // private PackedScene _player = GD.Load<PackedScene>("res://entities/player/player.tscn");
    
    public override void _Ready()
    {
        // _overworld = GetNode<Node2D>("Overworld");

        // Events.Instance.LifecycleStartGame += OnLifecycleStartGame;
        // Events.Instance.LifecycleEnterWorld += OnLifecycleEnterWorld;
    }
    
    // Define singleton logic
    public static SceneManager Instance { get; private set; }
    public override void _EnterTree()
    {
        if (Instance != null) QueueFree(); // The Singleton is already loaded, kill this instance
        Instance = this;
    }
}