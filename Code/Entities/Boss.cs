using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class Boss : Sprite
{
    private float _maxHealthPoint = 180;
    private float _currentHealthPoint = 180;
    private Blink _blink;
    private PackedScene[] _bossAoEs;
    private Vector2 _centerVector;
    public float GetCurrentHealth() => _currentHealthPoint;
    private float GetHealthPercentage() => (_currentHealthPoint/_maxHealthPoint) * 100;
    public void AoEHit() => Global.Player?.TakeDamage();
    private void RemoveBoss()
    {
        Global.Boss = null;
        QueueFree();
    }

    public void TakeDamage((float damage, bool isCritical) hit)
    {
        _currentHealthPoint -= hit.damage;
        Global.BossLifebar.UpdateLifeBar(hit.damage.ToString(), hit.isCritical);
        _blink.Start();
        if(_currentHealthPoint <= 0)
            RemoveBoss();
    }
    public override void _Ready()
    {
        _bossAoEs = new PackedScene[]
        {
            Armory.AoEsByName["AoEH"],
            Armory.AoEsByName["AoE4Squares"],
            Armory.AoEsByName["AoEBarcode"],
            Armory.AoEsByName["AoE3Circles"],
            Armory.AoEsByName["AoE3CirclesVariant"],
            Armory.AoEsByName["AoEDoughnutH"],
            Armory.AoEsByName["AoEDoughnutV"]
        };
        _blink = new Blink(Material as ShaderMaterial, GetNode<Timer>("BlinkTimer"));
        _centerVector = new Vector2(GetViewportRect().Size.x/2, GetViewportRect().Size.y/2);
        Global.Boss = this;
        Global.BossLifebar.SetMaxValue(_maxHealthPoint);
        Global.BossLifebar.SetValue(_currentHealthPoint);
    }
    private void LaunchRandomAoE(int numberOfAoE)
    {
        List<int> indexes = Enumerable.Range(0, _bossAoEs.Length).ToList();
        for(int i = 0; i < numberOfAoE; i++)
        {
            int index = Global.Rng.Next(0, indexes.Count);
            Area2D AoE = (Area2D)_bossAoEs[indexes[index]].Instance();
            AoE.SetAsToplevel(true);
            AoE.GlobalPosition = _centerVector;
            AddChild(AoE);
            indexes.RemoveAt(index);
        }
    }

    public void _OnTimerTimeout()
    {
        if (GetHealthPercentage() >= 70)
            LaunchRandomAoE(3);
        else if (GetHealthPercentage() >= 40)
            LaunchRandomAoE(3);
        else
            LaunchRandomAoE(3);
    }
    public void _OnBlinkTimerTimeout()
    {
        _blink.TriggerBlink();
    }
}
