using Godot;
using Godot.Collections;
using System.Collections.Generic;

public class AoECircles : Area2D
{
    private Boss _owner;
    private Timer _timer;
    private Array _children;
    private ShaderMaterial[] _shaders;
    private bool _coliding;

    public override void _Ready()
    {
        _owner = Global.CurrentBoss;
        _children = GetChildren();
        _timer = GetNode<Timer>("Timer");
        _shaders = new ShaderMaterial[_children.Count - 1];
        for(int index = 0; index < _children.Count; index++)
        {
            if (_children[index] is CollisionShape2D collisionShape)
                _shaders[index] = collisionShape.GetNode<Sprite>("Visual").Material as ShaderMaterial;
        }
    }

    public override void _Process(float delta)
    {
        for(int index = 0; index < _shaders.Length; index++)
            _shaders[index].SetShaderParam("opacity", _timer.TimeLeft * 2.5f);
    }

    public void _OnTimerTimeout()
    {
        if (_coliding)
            _owner.AoEHit();
        QueueFree();
    }
    public void _OnAoEbodyEntered(Node body)
    {
        _coliding = true;
    }
    public void _OnAoEBodyExited(Node body)
    {
        _coliding = false;
    }
}
