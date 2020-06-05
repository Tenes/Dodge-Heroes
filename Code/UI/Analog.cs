using Godot;
using System;

public class Analog : Node2D
{
    private const string PLAYER_NODE_PATH = "/root/Combat/Player";
    private const sbyte INACTIVE_INDEX = -1;
    private const bool IS_DYNAMICALLY_SHOWING = true;
    private Sprite _outerAnalog;
    private Sprite _innerAnalog;
    private AnimationPlayer _analogAnimation;
    private Control _parentNode;
    private Player _playerNode;
    private Vector2 _centerPoint = new Vector2(0, 0);
    private Vector2 _currentForce = new Vector2(0, 0);
    private Vector2 _halfSize = new Vector2();
    private Vector2 _analogPosition = new Vector2();
    private float _squaredHalfSize = 0;
    private int _currentIndex = INACTIVE_INDEX;

    private Vector2 GetForce() => _currentForce;
    private bool IsActive() => _currentIndex != INACTIVE_INDEX;
    private new void Hide() => _analogAnimation.Play("alpha_out", 0.2f);
    private void ShowAtPosition(Vector2 position)
    {
        if (IS_DYNAMICALLY_SHOWING)
        {
            _analogAnimation.Play("alpha_in", 0.2f);
            GlobalPosition = position;
        }
    }
    private bool NeedToChangeActiveButton(InputEvent inputEvent)
    {
        if (inputEvent is InputEventScreenTouch inputEventScreenTouch)
        {
            Vector2 mousePosition = new Vector2(inputEventScreenTouch.Position.x, inputEventScreenTouch.Position.y);
            if (IS_DYNAMICALLY_SHOWING)
                return _parentNode.GetGlobalRect().HasPoint(mousePosition);
            else
            {
                float length = (GlobalPosition - mousePosition).Length();
                return length < _squaredHalfSize;
            }
        }
        else
            return false;
    }
    
    private int ExtractIndex(InputEvent inputEvent)
    {
        if (inputEvent is InputEventScreenTouch inputEventScreenTouch)
            return inputEventScreenTouch.Index;
        else if(inputEvent is InputEventScreenDrag inputEventScreenDrag)
            return inputEventScreenDrag.Index;
        else
            return INACTIVE_INDEX;
    }
    private void ProcessInput(InputEvent inputEvent)
    {
        if (inputEvent is InputEventScreenTouch inputEventScreenTouch)
        {
            CalculateForce(inputEventScreenTouch.Position.x - GlobalPosition.x, inputEventScreenTouch.Position.y - GlobalPosition.y);
            UpdateAnalogPosition();
        }
        else if(inputEvent is InputEventScreenDrag inputEventScreenDrag)
        {
            CalculateForce(inputEventScreenDrag.Position.x - GlobalPosition.x, inputEventScreenDrag.Position.y - GlobalPosition.y);
            UpdateAnalogPosition();
        }

        if (IsReleased(inputEvent))
            Reset();
    }
    private void Reset()
    {
        _currentIndex = INACTIVE_INDEX;
        CalculateForce(0, 0);
        if (IS_DYNAMICALLY_SHOWING)
            Hide();
        else
            UpdateAnalogPosition();
    }
    private bool IsPressed(InputEvent inputEvent)
    {
        if (inputEvent is InputEventScreenTouch inputEventScreenTouch)
            return inputEventScreenTouch.IsPressed();
        return false;
    }
    private bool IsReleased(InputEvent inputEvent)
    {
        if (inputEvent is InputEventScreenTouch inputEventScreenTouch)
            return !inputEventScreenTouch.IsPressed();
        return false;
    }
    private void UpdateAnalogPosition()
    {
        _analogPosition.x = _halfSize.x * _currentForce.x;
        _analogPosition.y = _halfSize.y * -_currentForce.y;
        _innerAnalog.Position = new Vector2(_analogPosition.x, _analogPosition.y);
    }
    private void CalculateForce(float x, float y)
    {
        _currentForce.x = (x - _centerPoint.x) / _halfSize.x;
        _currentForce.y = -(y - _centerPoint.y) / _halfSize.y;

        if (_currentForce.LengthSquared() > 1)
            _currentForce = _currentForce / _currentForce.Length();
        SendSignal2Listener();
    }

    
    public override void _Ready()
    {
        SetProcessInput(true);
        _outerAnalog = GetNode<Sprite>("Outer");
        _innerAnalog = GetNode<Sprite>("Inner");
        _analogAnimation = GetNode<AnimationPlayer>("AnimationPlayer");
        _parentNode = GetParent<Control>();
        _halfSize = _outerAnalog.Texture.GetSize()/2;
        _squaredHalfSize = _halfSize.x * _halfSize.y;
        Reset();

        _playerNode = GetNode<Player>(PLAYER_NODE_PATH);
    }
    public override void _Input(InputEvent @event)
    {
        int incomingIndex = ExtractIndex(@event);
        if (incomingIndex == INACTIVE_INDEX)
            return;
        
        if (NeedToChangeActiveButton(@event))
        {
            if (_currentIndex != incomingIndex && @event.IsPressed())
            {
                _currentIndex = incomingIndex;
                ShowAtPosition(GetMousePositionFromEvent(@event));
            }
        }
        
        if (IsActive() && _currentIndex == incomingIndex)
            ProcessInput(@event);
    }
    private Vector2 GetMousePositionFromEvent(InputEvent inputEvent)
    {
        if (inputEvent is InputEventScreenTouch inputEventScreenTouch)
            return new Vector2(inputEventScreenTouch.Position.x, inputEventScreenTouch.Position.y);
        else if(inputEvent is InputEventScreenDrag inputEventScreenDrag)
            return new Vector2(inputEventScreenDrag.Position.x, inputEventScreenDrag.Position.y);
        else
            return new Vector2();
    }
    private void SendSignal2Listener()
    {
        if (_playerNode != null)
            _playerNode.AnalogForceChange(_currentForce, this);
    }

}
