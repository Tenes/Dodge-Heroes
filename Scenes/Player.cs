using Godot;
using System;

public class Player : KinematicBody2D
{
    private Vector2 _velocity = new Vector2(0, 0);
    private Vector2 _analogVelocity = new Vector2(0, 0);
    private int _speed = 300;

    public void AnalogForceChange(Vector2 force, Node2D analog)
    {
        if (force.Length() < 0.1)
            _analogVelocity = Vector2.Zero;
        else
            _analogVelocity = new Vector2(force.x, -force.y);
    }

    public override void _Process(float delta)
    {
        _velocity = Vector2.Zero;
        _velocity += _analogVelocity;

        if (_velocity.Length() > 0)
            _velocity = _velocity.Normalized() * _speed;
        Position += _velocity * delta;
    }
}
