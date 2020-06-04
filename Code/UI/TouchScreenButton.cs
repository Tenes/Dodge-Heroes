using Godot;
using System;

public class TouchScreenButton : Godot.TouchScreenButton
{
	private readonly Vector2 _radius = new Vector2(3, 3);
	private const byte _boundary = 6;
	private int _touchIndex = -1;
	private const byte _returnSpeed = 30;
	private byte _threshold = 10;

	private Vector2 GetButtonPosition()
	{
		return Position + _radius;
	}

	private Vector2 GetValue()
	{
		if (GetButtonPosition().Length() > _threshold)
			return GetButtonPosition().Normalized();

		return new Vector2(0, 0);
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventScreenTouch inputEventTouch && @event.IsPressed())
		{
			float distFromCenter = (inputEventTouch.Position - GetParent<Node2D>().GlobalPosition).Length();
			if (distFromCenter <= _boundary * GlobalScale.x || inputEventTouch.Index == _touchIndex)
				GlobalPosition = inputEventTouch.Position - _radius * GlobalScale;
			if (GetButtonPosition().Length() > _boundary)
				Position = GetButtonPosition().Normalized() * _boundary - _radius;
			_touchIndex = inputEventTouch.Index;

		}
		else if (@event is InputEventScreenDrag inputEventDrag)
		{
			float distFromCenter = (inputEventDrag.Position - GetParent<Node2D>().GlobalPosition).Length();
			if (distFromCenter <= _boundary * GlobalScale.x || inputEventDrag.Index == _touchIndex)
				GlobalPosition = inputEventDrag.Position - _radius * GlobalScale;
			if (GetButtonPosition().Length() > _boundary)
				Position = GetButtonPosition().Normalized() * _boundary - _radius;
			_touchIndex = inputEventDrag.Index;
		}
		if (@event is InputEventScreenTouch inputEventTouch2 && !@event.IsPressed() && inputEventTouch2.Index == _touchIndex)
			_touchIndex = -1;
		
	}

	public override void _Process(float delta)
	{
		if (_touchIndex == -1)
		{
			Vector2 positionDifference = -_radius - Position;
			Position += positionDifference * _returnSpeed * delta;
		}
	}
}
