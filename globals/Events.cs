using Godot;

namespace CSGameTemplate.globals;

/// <summary>
/// Singleton Events that can be emitted/consumed from anywhere.
/// </summary>
public partial class Events : Node
{
    // TODO: Once event classes are needed or to enforce parameter type checking on the receiver,
    //  refactor into something like https://www.reddit.com/r/godot/comments/131s509/comment/k5inzkn/?utm_source=share&utm_medium=web3x&utm_name=web3xcss&utm_term=1&utm_content=share_button
    
    // Signals should be past tense actions, where subscribers can react to them
    
    // Lifecycle signals
    [Signal]
    public delegate void LifecycleStartGameRequestedEventHandler();
    
    
    // Define singleton logic
    public static Events Instance { get; private set; }
    public override void _EnterTree()
    {
        if (Instance != null) QueueFree(); // The Singleton is already loaded, kill this instance
        Instance = this;
    }
}