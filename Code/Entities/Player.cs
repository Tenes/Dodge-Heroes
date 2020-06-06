using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class Player : KinematicBody2D
{
    [Export] public Dictionary<int, BaseClass> AvailableClasses;
    private List<BaseClass> EquipedClasses;
    private BaseClass _currentClass;
    private Classes classFlag;
    private byte _firstClassCooldown;
    private byte _secondClassCooldown;
    private byte _thirdClassCooldown;
    //Movement Related Attributes
    private Vector2 _velocity = new Vector2(0, 0);
    private Vector2 _analogVelocity = new Vector2(0, 0);

    //Properties
    public void SetClass(Classes newClass)
    {
        this.classFlag = newClass;
        this._currentClass = this.AvailableClasses[(int)classFlag];
        this.UpdateTexture();
    }
    
    //Functions
    private void UpdateTexture()
    {
        switch(this.classFlag)
        {
            case Classes.Warrior:
                GetNode<Sprite>("Sprite").Texture = (Texture)GD.Load("res://Assets/Sprites/Warrior.png");
                break;
            case Classes.Archer:
                GetNode<Sprite>("Sprite").Texture = (Texture)GD.Load("res://Assets/Sprites/Archer.png");
                break;
            case Classes.Mage:
                GetNode<Sprite>("Sprite").Texture = (Texture)GD.Load("res://Assets/Sprites/Mage.png");
                break;
        }
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
        this._currentClass = this.EquipedClasses.First();
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
