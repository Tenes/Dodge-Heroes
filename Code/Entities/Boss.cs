using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class Boss : Sprite
{
    private float _maxHealthPoint = 180;
    private float _currentHealthPoint = 180;
    private PackedScene[] _bossAoEs;
    private Random _bossRng;
    private Vector2 _centerVector;
    private float GetHealthPercentage() => (_currentHealthPoint/_maxHealthPoint) * 100;
    public void AoEHit() => Global.Player.TakeDamage();

    public void TakeDamage(int damage)
    {
        _currentHealthPoint -= damage;
        Global.BossLifebar.Value = _currentHealthPoint;
    }
    public override void _Ready()
    {
        _bossAoEs = new PackedScene[]
        {
            Armory.AoEsByName["AoEH"],
            Armory.AoEsByName["AoEBarcode"],
            Armory.AoEsByName["AoE3Circles"],
            Armory.AoEsByName["AoE3CirclesVariant"]
        };
        _bossRng = new Random();
        _centerVector = new Vector2(GetViewportRect().Size.x/2, GetViewportRect().Size.y/2);
        Global.Boss = this;
        Global.BossLifebar.MaxValue = _maxHealthPoint;
        Global.BossLifebar.Value = _currentHealthPoint;
    }
    private void LaunchRandomAoE(int numberOfAoE)
    {
        List<int> indexes = Enumerable.Range(0, _bossAoEs.Length).ToList();
        for(int i = 0; i < numberOfAoE; i++)
        {
            int index = _bossRng.Next(0, indexes.Count);
            var AoE = (Area2D)_bossAoEs[indexes[index]].Instance();
            AoE.SetAsToplevel(true);
            AoE.GlobalPosition = _centerVector;
            AddChild(AoE);
            indexes.RemoveAt(index);
        }
    }


    public void _OnTimerTimeout()
    {
        if (GetHealthPercentage() >= 70)
            LaunchRandomAoE(1);
        else if (GetHealthPercentage() >= 40)
            LaunchRandomAoE(2);
        else
            LaunchRandomAoE(3);
    }

}
