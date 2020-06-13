using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class Player : KinematicBody2D
{
    protected byte _maxHealthPoint = 3;
    protected byte _currentHealthPoint = 3;
    private int _numberOfBlink = 0;
    private int _maxNumberOfBlink = 4;
    private bool _blinkBool = true;
    private Sprite _sprite;
    private ShaderMaterial _shader;
    private List<BaseClass> _equipedClasses;
    private BaseClass _currentClass;
    private Classes _classFlag;
    private Classes _previousClassFlag;
    private ActualClassSprite _actualClassSprite;
    private ChangeClassButton _firstClassChangeButton;
    private ChangeClassButton _secondClassChangeButton;
    private Timer _autoAttackTimer;
    private Timer _blinkTimer;
    //Movement Related Attributes
    private Vector2 _velocity = new Vector2(0, 0);
    private Vector2 _analogVelocity = new Vector2(0, 0);
    private void SetAutoAttackTimerOnClassAttackSpeed() => _autoAttackTimer.WaitTime = _currentClass.GetAttackspeed();
    //Properties
    public void TakeDamage()
    {
        _currentHealthPoint -= 1;
        //SHADER STUFF HERE
        Global.PlayerHealthUI.UpdateUI(_currentHealthPoint);
        if (_currentHealthPoint == 0)
            QueueFree();
    }
    public Classes GetClassFlag() => _classFlag;
    public void SetClass(Classes newClass)
    {
        _previousClassFlag = _classFlag;
        _classFlag = newClass;
        _currentClass = Armory.AvailableClasses[_classFlag];
        UpdateTexture();
        _blinkTimer.Start();
        SetAutoAttackTimerOnClassAttackSpeed();
    }
    
    //Functions
    private void UpdateTexture()
    {
        _sprite.Texture = Armory.ClassesTexture[_classFlag];
    }

    public void AnalogForceChange(Vector2 force, Node2D analog)
    {
        if (force.Length() < 0.1)
            _analogVelocity = Vector2.Zero;
        else
            _analogVelocity = new Vector2(force.x, -force.y);
    }

    //Godot Functions
    public override void _Ready()
    {
        _sprite = GetNode<Sprite>("Sprite");
        _shader = _sprite.Material as ShaderMaterial;
        _equipedClasses = new List<BaseClass>
        {
            Armory.AvailableClasses[Classes.Warrior],
            Armory.AvailableClasses[Classes.Archer],
            Armory.AvailableClasses[Classes.Mage]
        };
        _currentClass = _equipedClasses.First();
        _classFlag = _currentClass.GetClassFlag();
        _actualClassSprite = GetNode<ActualClassSprite>("/root/Combat/UI/CurrentClass");
        _firstClassChangeButton = GetNode<ChangeClassButton>("/root/Combat/UI/FirstChangeButton");
        _secondClassChangeButton = GetNode<ChangeClassButton>("/root/Combat/UI/SecondChangeButton");
        _autoAttackTimer = GetNode<Timer>("AutoAttackTimer");
        _blinkTimer = GetNode<Timer>("BlinkTimer");

        _actualClassSprite.SetIconForClass(_classFlag);
        _firstClassChangeButton.SetClassHeld(_equipedClasses[1].GetClassFlag());
        _secondClassChangeButton.SetClassHeld(_equipedClasses[2].GetClassFlag());
        Global.Player = this;
        Global.PlayerHealthUI.UpdateUI(_currentHealthPoint);
    }
    public override void _PhysicsProcess(float delta)
    {
        _velocity = Vector2.Zero;
        _velocity += _analogVelocity;

        if (_velocity.Length() > 0)
            _velocity = _velocity.Normalized() * _currentClass.GetMovespeed();
        MoveAndSlide(_velocity, maxSlides: 2);
    }

    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventKey inputKey && inputKey.Scancode == (int)KeyList.Space)
            Global.Boss.TakeDamage(_currentClass.GetDamage());
    }
    public void _OnAutoAttackTimerTimeout()
    {
        Global.Boss.TakeDamage(_currentClass.GetDamage());
    }
    public void _OnBlinkTimerTimeout()
    {
        if(_numberOfBlink < _maxNumberOfBlink)
        {
            _shader.SetShaderParam("blinking", _blinkBool);
            _blinkBool = !_blinkBool;
            _numberOfBlink += 1;

        }
        else
        {
            _blinkTimer.Stop();
            _numberOfBlink = 0;
        }
    }
}
