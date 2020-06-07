using Godot;
using System;

public class CombatScene : Node2D
{
    private float _timerForGarbageCollection = 0;
    private float _timeToHit = 3f;
    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        this._timerForGarbageCollection += delta;
        if(this._timerForGarbageCollection >= this._timeToHit)
        {
            GD.Print(GC.MaxGeneration);
            GC.Collect(0);
            GC.WaitForPendingFinalizers();
            this._timerForGarbageCollection= 0;
        }
    }
}
