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
}
