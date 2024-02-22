# CS Game Template

## Description
This is a small repo with the basic files needed to create a C# based game in godot without having to perform this process each time.

## Creating a new game from this template

1. Clone/fork this repo and rename
2. Create a new Godot project in the same directory
3. Setup C# SLN file

Go to Project > Tools > C# > Create C# Solution

Then open the solution within Rider, and ensure you have the Godot plugin installed.

It should automatically load the Godot interface, but if it doesn't (which it didn't for me) you can right click the .sln file within Rider and open it (even if the project is already open). It should then detect it and work.

## Project structure
Adapted from: https://www.reddit.com/r/godot/comments/7786ee/what_the_best_folder_structure_for_developement/

```
/
    entities/
        player/
            player.tscn
            player.gd
        enemies/
            generic_enemy.gd
            enemy.tscn #base scene to be overridden
            boss_enemy.gd
            boss.tscn #base scene to be overridden
        actor.tscn
        actor.tres
        actor.gd
    globals/ #used as autoloads
        notifications.tscn
        lobby.tscn
        serialization.tscn
    menus/ #for scenes that are used standalone 2d menus, or popups
        title/
            title.tscn
            font_title.tres
    ui/ #for any assets related to UI that are reused
        theme_default/
            assets/
                [...] #generally pngs for interface
            theme_default.tres
        font_uidefault.tres
        cool_font.ttf
    scenes/ #scenes where a player will probably be instantiated
         common/
             assets/
                 [...]
             prefabs/ #premade designs for inclusion in a level elsewhere
                 [...].tscn
             common_gridmap.tres
         main/
             assets/
                 [...]
             main.tscn
             [...]
         overworld/
             assets/
                 [...]
             overworld.tscn
             [...]
         dungeon/
             assets/
                 [...]
             dungeon.tscn
             [...]
```