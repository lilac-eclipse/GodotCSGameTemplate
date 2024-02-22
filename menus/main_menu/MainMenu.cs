using Godot;
using LilacRPG.globals;

namespace LilacRPG.menus.main_menu;

public partial class MainMenu : CanvasLayer
{
    private Button _hostButton;
    private Button _joinLocalButton;
    private Button _joinRemoteButton;
    private LineEdit _addressEntry;
    private Label _ipLabel;
    
    public override void _Ready()
    {
        _hostButton = GetNode<Button>("%HostButton");
        _joinLocalButton = GetNode<Button>("%JoinLocalButton");
        _joinRemoteButton = GetNode<Button>("%JoinRemoteButton");
        _addressEntry = GetNode<LineEdit>("%AddressEntry");
        _ipLabel = GetNode<Label>("%IPLabel");

        _hostButton.Pressed += OnHostButtonPressed;
        _joinLocalButton.Pressed += OnJoinLocalButtonPressed;
        _joinRemoteButton.Pressed += OnJoinRemoteButtonPressed;
        
        SetIpAddressLabel();
    }

    private void SetIpAddressLabel()
    {
        var ip = MpManager.Instance.GetPrivateIp();
        _ipLabel.Text = "IP: " + ip;
    }

    private void OnHostButtonPressed()
    {
        MpManager.Instance.Host();
        Events.Instance.EmitSignal(Events.SignalName.LifecycleEnterWorld);
    }

    private void OnJoinLocalButtonPressed()
    {
        MpManager.Instance.Connect("localhost");
        Events.Instance.EmitSignal(Events.SignalName.LifecycleEnterWorld);
    }

    private void OnJoinRemoteButtonPressed()
    {
        MpManager.Instance.Connect(_addressEntry.Text);
        Events.Instance.EmitSignal(Events.SignalName.LifecycleEnterWorld);
    }
}