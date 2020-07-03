using Godot;
using System;

public class CombatScene : Node2D
{
    private float _timerForGarbageCollection = 0;
    private float _timeToHit = 10f;
    public override void _Ready()
    {
        AddChild(Global.CurrentBoss);
        MoveChild(Global.CurrentBoss, 2);
    }

    public override void _Process(float delta)
    {
        _timerForGarbageCollection += delta;
        if(_timerForGarbageCollection >= _timeToHit)
        {
            GC.Collect(0);
            GC.WaitForPendingFinalizers();
            _timerForGarbageCollection= 0;
        }
    }
}
