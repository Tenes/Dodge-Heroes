using Godot;
using System;

public class Lifebar : HBoxContainer
{
    private Boss _boss;
    private TextureProgress _filledBar;
    public override void _Ready()
    {
        _filledBar = GetNode<TextureProgress>("TextureProgress");
        Global.BossLifebar = _filledBar;
    }

}
