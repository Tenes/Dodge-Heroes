using Godot;
using System;

public class FloatingText : Position2D
{
    private string _text;
    private Label _label;
    private Tween _tween;
    private Vector2 _velocity;
    private Vector2 _maxScale;
    private Color _color;

    public FloatingText()
    {
        _maxScale = new Vector2(0.65f, 0.65f);
        _color = new Color(0.7f, 0.1f, 0.1f);
    }
    public void SetText(string text) => _text = text;

    public override void _Ready()
    {
        _label = GetNode<Label>("Label");
        _label.AddColorOverride("font_color", _color);
        _label.Text = _text;
        _tween = GetNode<Tween>("Tween");
        _velocity = new Vector2(Global.Rng.Next(-80, 81), 50);
        _tween.InterpolateProperty(this, "scale", Scale, _maxScale, 0.2f, Tween.TransitionType.Linear, Tween.EaseType.Out);
        _tween.InterpolateProperty(this, "scale", _maxScale, new Vector2(0.1f, 0.1f), 0.4f, Tween.TransitionType.Linear, Tween.EaseType.Out, 0.3f);
        _tween.Start();
    }
    public void SetCriticalValues(bool critical)
    {
        if (!critical)
            return;
        _maxScale = new Vector2(1.1f, 1.1f);
        _color = new Color(0.9f, 0.9f, 0.1f);
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
