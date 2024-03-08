using System.Text.Json;
using CSGameTemplate.scenes.game;
using Godot;

namespace CSGameTemplate.globals;

public class SaveData
{
    public GameState GameState { get; init; }
}
public partial class SaveDataWrapper : Node
{
    public SaveData SaveData { get; set; } // Cannot expose a setter, or consumers of this object may not use the new obj ref

    public void Save()
    {
        using var saveGame = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Write);
        string jsonString = JsonSerializer.Serialize(SaveData);
        saveGame.StoreLine(jsonString);
        Logger.Instance.Info("Game saved with data: " + jsonString);
        
        Logger.Instance.Debug(Instance.SaveData.GameState.Count.ToString());
    }

    public void Load()
    {
        if (!FileAccess.FileExists("user://savegame.save"))
        {
            Logger.Instance.Info("No game save file to load, creating new!");
            SaveData = new();
            return;
        }
        
        using var saveGame = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Read);
        var jsonString = saveGame.GetLine();
        SaveData = JsonSerializer.Deserialize<SaveData>(jsonString);
        Logger.Instance.Info("Game loaded with data: " + jsonString);
    }
    
    // Singleton logic
    public static SaveDataWrapper Instance { get; private set; }
    public override void _EnterTree()
    {
        if (Instance != null) QueueFree(); // The Singleton is already loaded, kill this instance
        Instance = this;
    }
}