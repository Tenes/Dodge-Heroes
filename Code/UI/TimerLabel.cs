using Godot;
using System;

public class TimerLabel : Label
{
    private Timer _parentTimer;
    public new void Hide()
    {
        SetProcess(false);
        Visible = false;
    }
    public new void Show()
    {
        SetProcess(true);
        Visible = true;
    }
    public override void _Ready()
    {
        _parentTimer = GetParent<Timer>();
    }

    public override void _Process(float delta)
    {
        Text = Mathf.Ceil(_parentTimer.TimeLeft).ToString();
    }
}
