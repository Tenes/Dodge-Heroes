using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class Player : KinematicBody2D
{
    private byte _maxHealthPoint = 3;
    private byte _currentHealthPoint = 3;
    private bool _notMoving;
    private Sprite _sprite;
    private Blink _blink;
    private List<BaseClass> _equipedClasses;
    private BaseClass _currentClass;
    private Classes _classFlag;
    private Classes _previousClassFlag;
    private ActualClassSprite _actualClassSprite;
    private ChangeClassButton _firstClassChangeButton;
    private ChangeClassButton _secondClassChangeButton;
    private Timer _autoAttackTimer;
    //Movement Related Attributes
    private Vector2 _velocity = new Vector2(0, 0);
    private Vector2 _analogVelocity = new Vector2(0, 0);
    private void SetAutoAttackTimerOnClassAttackSpeed()
    {
        _autoAttackTimer.WaitTime = _currentClass.GetAttackspeed();
        _autoAttackTimer.Start();
    }
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
        _blink.Start();
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
        _blink = new Blink(_sprite.Material as ShaderMaterial, GetNode<Timer>("BlinkTimer"));
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

        _actualClassSprite.SetIconForClass(_classFlag);
        _firstClassChangeButton.SetClassHeld(_equipedClasses[1].GetClassFlag());
        _secondClassChangeButton.SetClassHeld(_equipedClasses[2].GetClassFlag());
        Global.Player = this;
        Global.PlayerHealthUI.UpdateUI(_currentHealthPoint);
        SetAutoAttackTimerOnClassAttackSpeed();
    }
    public override void _PhysicsProcess(float delta)
    {
        _velocity = Vector2.Zero;
        _velocity += _analogVelocity;

        if (_velocity.Length() > 0)
        {
            _velocity = _velocity.Normalized() * _currentClass.GetMovespeed();
            if(_classFlag == Classes.Mage)
                _autoAttackTimer.Start();
            else if(_classFlag == Classes.Warrior)
            {
                if (Position.y <= 300 && _autoAttackTimer.IsStopped())
                    _autoAttackTimer.Start();
                else if (Position.y > 300)
                    _autoAttackTimer.Stop();
            }
        }
        MoveAndSlide(_velocity, maxSlides: 2);
    }

    // Signals
    public void _OnAutoAttackTimerTimeout()
    {
        Global.Boss.TakeDamage(_currentClass.GetDamage());
    }
    public void _OnBlinkTimerTimeout()
    {
        _blink.TriggerBlink();
    }
}
