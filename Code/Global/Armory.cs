using Godot;
using System.Collections.Generic;

public static class Armory
{
    public static Dictionary<Classes, BaseClass> AvailableClasses = new Dictionary<Classes, BaseClass>
    {
        {Classes.Warrior, new WarriorClass()},
        {Classes.Archer, new ArcherClass()},
        {Classes.Mage, new MageClass()}
    };
    public static Dictionary<Classes, Texture> ClassesTexture = new Dictionary<Classes, Texture>
    {
        {Classes.Warrior, (Texture)GD.Load("res://Assets/Sprites/Warrior.png")},
        {Classes.Archer, (Texture)GD.Load("res://Assets/Sprites/Archer.png")},
        {Classes.Mage, (Texture)GD.Load("res://Assets/Sprites/Mage.png")}
    };
    public static Dictionary<Classes, Rect2> ClassesButtonRegion = new Dictionary<Classes, Rect2>
    {
        {Classes.Warrior, new Rect2(new Vector2(180, 450), new Vector2(15, 15))},
        {Classes.Archer, new Rect2(new Vector2(162, 450), new Vector2(15, 15))},
        {Classes.Mage, new Rect2(new Vector2(198, 450), new Vector2(15, 15))}
    };
    public static Dictionary<string, PackedScene> AoEsByName = new Dictionary<string, PackedScene>
    {
        {"AoEH", GD.Load("res://Components/AoEH.tscn") as PackedScene}
    };
}
