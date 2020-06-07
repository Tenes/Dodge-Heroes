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
    //Movement Related Attributes
    private Vector2 _velocity = new Vector2(0, 0);
    private Vector2 _analogVelocity = new Vector2(0, 0);

    //Properties
    public Classes GetClassFlag() => this._classFlag;
    public void SetClass(Classes newClass)
    {
        this._previousClassFlag = this._classFlag;
        this._classFlag = newClass;
        this._currentClass = Armory.AvailableClasses[this._classFlag];
        this.UpdateTexture();
    }
    
    //Functions
    private void UpdateTexture()
    {
        this._sprite.Texture = Armory.ClassesTexture[this._classFlag];
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
        this._sprite = GetNode<Sprite>("Sprite");
        this._equipedClasses = new List<BaseClass>
        {
            Armory.AvailableClasses[Classes.Warrior],
            Armory.AvailableClasses[Classes.Archer],
            Armory.AvailableClasses[Classes.Mage]
        };
        this._currentClass = this._equipedClasses.First();
        this._classFlag = this._currentClass.GetClassFlag();
        this._actualClassSprite = GetNode<ActualClassSprite>("/root/Combat/UI/CurrentClass");
        this._firstClassChangeButton = GetNode<ChangeClassButton>("/root/Combat/UI/FirstChangeButton");
        this._secondClassChangeButton = GetNode<ChangeClassButton>("/root/Combat/UI/SecondChangeButton");

        GD.Print(this._actualClassSprite);
        GD.Print(this._classFlag);

        this._actualClassSprite.SetIconForClass(this._classFlag);
        this._firstClassChangeButton.SetClassHeld(this._equipedClasses[1].GetClassFlag());
        this._secondClassChangeButton.SetClassHeld(this._equipedClasses[2].GetClassFlag());
    }
    public override void _PhysicsProcess(float delta)
    {
        this._velocity = Vector2.Zero;
        this._velocity += _analogVelocity;

        if (_velocity.Length() > 0)
            this._velocity = this._velocity.Normalized() * this._currentClass.GetMovespeed();
        MoveAndSlide(this._velocity, maxSlides: 2);
    }
}
