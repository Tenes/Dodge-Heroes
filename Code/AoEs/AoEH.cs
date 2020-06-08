using Godot;
using System;

public class AoEH : Area2D
{
    private Timer _timer;
    private ShaderMaterial _shader;
    public override void _Ready()
    {
        _timer = GetNode<Timer>("Timer");
        _shader = GetNode<Polygon2D>("AoE").Material as ShaderMaterial;
    }

    public override void _Process(float delta)
    {
        _shader.SetShaderParam("opacity", _timer.TimeLeft * 2.5f);
    }

    public void _OnTimerTimeout()
    {
        QueueFree();
    }
}
