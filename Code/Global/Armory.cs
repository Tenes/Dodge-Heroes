using Godot;
using System.Collections.Generic;

public static class Armory
{
    public static PackedScene CombatScene = GD.Load("res://Scenes/Combat.tscn") as PackedScene;
    public static PackedScene CityScene = GD.Load("res://Scenes/City.tscn") as PackedScene;
    public static PackedScene FloatingText = GD.Load("res://Components/UI/FloatingText.tscn") as PackedScene;
    public static PackedScene QuestBoard = GD.Load("res://Components/UI/QuestBoard.tscn") as PackedScene;
    public static PackedScene QuestListItem = GD.Load("res://Components/UI/QuestListItem.tscn") as PackedScene;
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
    public static Dictionary<Classes, Texture> ClassesIcons = new Dictionary<Classes, Texture>
    {
        {Classes.Warrior, (Texture)GD.Load("res://Assets/UI/WarriorIcon.png")},
        {Classes.Archer, (Texture)GD.Load("res://Assets/UI/ArcherIcon.png")},
        {Classes.Mage, (Texture)GD.Load("res://Assets/UI/MageIcon.png")}
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
    public static List<PackedScene> Bosses = new List<PackedScene>
    {
        GD.Load("res://Components/Entities/Bosses/DragonBoss.tscn") as PackedScene,
        GD.Load("res://Components/Entities/Bosses/PhoenixBoss.tscn") as PackedScene
    };
}
