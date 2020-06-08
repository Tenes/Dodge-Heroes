using Godot;
using System;

public class TimerLabel : Label
{
    private Timer _parentTimer;
    public void SwitchHideVisible() => Visible = !Visible;
    public override void _Ready()
    {
        _parentTimer = GetParent<Timer>();
    }

    public override void _Process(float delta)
    {
        if(Visible)
            Text = Mathf.Ceil(_parentTimer.TimeLeft).ToString();
    }
}
