using Godot;
using Godot.Collections;
using System.Collections.Generic;

public class AoEDoughnuts : Area2D
{
    private Boss _owner;
    private Timer _timer;
    private Area2D _outerArea;
    private Array __outerAreaChildren;
    private ShaderMaterial[] _shaders;
    private bool _innerCollide;
    private bool _outerCollide;
    private bool _coliding()
    {
        if(!_innerCollide && _outerCollide)
            return true;
        return false;
    }

    public override void _Ready()
    {
        _owner = Global.CurrentBoss;
        _outerArea = GetNode<Area2D>("Outer");
        __outerAreaChildren = _outerArea.GetChildren();
        _timer = GetNode<Timer>("Timer");
        _shaders = new ShaderMaterial[__outerAreaChildren.Count];
        for(int index = 0; index < __outerAreaChildren.Count; index++)
        {
            if (__outerAreaChildren[index] is CollisionShape2D collisionShape2D)
                _shaders[index] = collisionShape2D.GetNode<Sprite>("Visual").Material as ShaderMaterial;
        }
    }

    public override void _Process(float delta)
    {
        for(int index = 0; index < _shaders.Length; index++)
            _shaders[index].SetShaderParam("opacity", _timer.TimeLeft * 2.5f);
    }

    public void _OnTimerTimeout()
    {
        if (_coliding())
            _owner.AoEHit();
        QueueFree();
    }
    public void _OnInnerAoEEntered(Node body)
    {
        _innerCollide = true;
    }
    public void _OnInnerAoEExited(Node body)
    {
        _innerCollide = false;
    }
    public void _OnOuterAoEEntered(Node body)
    {
        _outerCollide = true;
    }
    public void _OnOuterAoEExited(Node body)
    {
        _outerCollide = false;
    }
    
}
