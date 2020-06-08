using Godot;
using System;

public class CombatScene : Node2D
{
    private float _timerForGarbageCollection = 0;
    private float _timeToHit = 10f;
    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        _timerForGarbageCollection += delta;
        if(_timerForGarbageCollection >= _timeToHit)
        {
            GD.Print(GC.MaxGeneration);
            GC.Collect(0);
            GC.WaitForPendingFinalizers();
            _timerForGarbageCollection= 0;
        }
    }
}
