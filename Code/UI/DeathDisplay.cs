using Godot;
using System;

public class DeathDisplay : ColorRect
{
    public void _OnExitButtonReleased()
    {
        SceneTree tree = GetTree();
        tree.ChangeSceneTo(Armory.CityScene);
    }
}
