using Godot;
using System;

public class FloatingText : Position2D
{
    private string _text;
    private Label _label;
    private Tween _tween;
    private Vector2 _velocity;

    public void SetText(string text) => _text = text;

    public override void _Ready()
    {
        _label = GetNode<Label>("Label");
        _label.Text = _text;
        _tween = GetNode<Tween>("Tween");
        _velocity = new Vector2(Global.Rng.Next(-80, 81), 50);
        _tween.InterpolateProperty(this, "scale", Scale, new Vector2(1, 1), 0.2f, Tween.TransitionType.Linear, Tween.EaseType.Out);
        _tween.InterpolateProperty(this, "scale", new Vector2(1, 1), new Vector2(0.1f, 0.1f), 0.7f, Tween.TransitionType.Linear, Tween.EaseType.Out, 0.3f);
        _tween.Start();
    }

    public void _OnTweenAllCompleted()
    {
        QueueFree();
    }

    public override void _Process(float delta)
    {
        Position += _velocity * delta;
    }
}
