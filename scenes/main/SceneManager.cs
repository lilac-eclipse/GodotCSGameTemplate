using Godot;
using LilacRPG.globals;

namespace LilacRPG.scenes.main;

public partial class SceneManager : Node
{
    private Node2D _overworld;
    private PackedScene _player = GD.Load<PackedScene>("res://entities/player/player.tscn");

    public override void _Ready()
    {
        _overworld = GetNode<Node2D>("Overworld");

        Events.Instance.LifecycleStartGame += OnLifecycleStartGame;
        Events.Instance.LifecycleEnterWorld += OnLifecycleEnterWorld;
    }

    private void OnLifecycleStartGame()
    {
        _overworld.Hide();
    }

    private void OnLifecycleEnterWorld()
    {
        _overworld.Show();
        if (MpManager.Instance.IsHost) 
            MpManager.Instance.ConfigureInstantiateSceneOnClientJoin(_player, _overworld);
        
    }
}