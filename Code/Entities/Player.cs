using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class Player : KinematicBody2D
{
    private List<BaseClass> _equipedClasses;
    private BaseClass _currentClass;
    private Classes _classFlag;
    private Classes _previousClassFlag;
    private Sprite _sprite;
    private ActualClassSprite _actualClassSprite;
    private ChangeClassButton _firstClassChangeButton;
    private ChangeClassButton _secondClassChangeButton;
    private ShaderMaterial _shader;
    private float _timerElpased = 0;
    private float _tintTime = 0.05f;
    private int _numberOfTint = 0;
    private bool _tintBool = false;
    //Movement Related Attributes
    private Vector2 _velocity = new Vector2(0, 0);
    private Vector2 _analogVelocity = new Vector2(0, 0);

    //Properties
    public Classes GetClassFlag() => _classFlag;
    public void SetClass(Classes newClass)
    {
        _previousClassFlag = _classFlag;
        _classFlag = newClass;
        _currentClass = Armory.AvailableClasses[_classFlag];
        UpdateTexture();
        _numberOfTint = 3;
        _tintBool = false;
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

        _actualClassSprite.SetIconForClass(_classFlag);
        _firstClassChangeButton.SetClassHeld(_equipedClasses[1].GetClassFlag());
        _secondClassChangeButton.SetClassHeld(_equipedClasses[2].GetClassFlag());
    }
    public override void _PhysicsProcess(float delta)
    {
        _velocity = Vector2.Zero;
        _velocity += _analogVelocity;

        if (_velocity.Length() > 0)
            _velocity = _velocity.Normalized() * _currentClass.GetMovespeed();
        MoveAndSlide(_velocity, maxSlides: 2);
    }

    public override void _Process(float delta)
    {
        if(_timerElpased >= _tintTime && _numberOfTint > 0)
        {
            _shader.SetShaderParam("changing_class", _tintBool);
            _tintBool = !_tintBool;
            _timerElpased = 0;
            _numberOfTint -= 1;
        }
        _timerElpased += delta;
    }
}
