using Godot;

namespace globals;

/// <summary>
/// Singleton Events that can be emitted/consumed from anywhere.
/// </summary>
public partial class Events : Node
{
    // TODO: Signals should be past tense actions, where subscribers can react to them
    // TODO: Refactor into something like https://www.reddit.com/r/godot/comments/131s509/event_bus_in_godot_4/
    
    // Lifecycle signals
    [Signal]
    public delegate void LifecycleStartGameEventHandler();
    
    
    // Define singleton logic
    public static Events Instance { get; private set; }
    public override void _EnterTree()
    {
        if (Instance != null) QueueFree(); // The Singleton is already loaded, kill this instance
        Instance = this;
    }
}