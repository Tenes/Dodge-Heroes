using Godot;
using System;

public class Boss : Sprite
{
    private Node[] _bossAoEs;
    private Node _rootNode;
    public override void _Ready()
    {
        _bossAoEs = new Node[]
        {
            Armory.AoEsByName["AoEH"].Instance()
        }
    }

}
