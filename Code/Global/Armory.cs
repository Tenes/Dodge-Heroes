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
    public static Dictionary<string, Texture> UITextures = new Dictionary<string, Texture>
    {
        {"HeartFull", (Texture)GD.Load("res://Assets/UI/HeartFull.png")},
        {"HeartEmpty", (Texture)GD.Load("res://Assets/UI/HeartEmpty.png")}
    };
    public static Dictionary<string, PackedScene> AoEsByName = new Dictionary<string, PackedScene>
    {
        {"AoEH", GD.Load("res://Components/AoEs/AoEH.tscn") as PackedScene},
        {"AoE4Squares", GD.Load("res://Components/AoEs/AoE4Squares.tscn") as PackedScene},
        {"AoEBarcode", GD.Load("res://Components/AoEs/AoEBarcode.tscn") as PackedScene},
        {"AoE3Circles", GD.Load("res://Components/AoEs/AoE3Circles.tscn") as PackedScene},
        {"AoE3CirclesVariant", GD.Load("res://Components/AoEs/AoE3CirclesVariant.tscn") as PackedScene},
        {"AoEDoughnutH", GD.Load("res://Components/AoEs/AoEDoughnutH.tscn") as PackedScene},
        {"AoEDoughnutV", GD.Load("res://Components/AoEs/AoEDoughnutV.tscn") as PackedScene}
    };
    public static PackedScene FloatingText = GD.Load("res://Components/UI/FloatingText.tscn") as PackedScene;
}
