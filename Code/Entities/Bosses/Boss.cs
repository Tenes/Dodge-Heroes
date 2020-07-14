using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class Boss : Sprite
{
    protected string _title;
    protected float _maxHealthPoint;
    protected float _currentHealthPoint;
    protected int _moneyValue;
    protected Blink _blink;
    protected PackedScene[] _bossAoEs;
    protected Vector2 _centerVector;
    public string GetTitle() => _title;
    public float GetCurrentHealth() => _currentHealthPoint;
    protected float GetHealthPercentage() => (_currentHealthPoint/_maxHealthPoint) * 100;
    public void AoEHit() => Global.Player?.TakeDamage();
    protected void RemoveBoss()
    {
        Global.PlayerData.AddMoney(_moneyValue);
        GetParent().GetNode<CanvasLayer>("UI").AddChild(Armory.LootDisplay.Instance());
        Global.Player.PauseAutoAttack();
        Global.CurrentBoss = null;
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
        _blink = new Blink(Material as ShaderMaterial, GetNode<Timer>("BlinkTimer"));
        _centerVector = new Vector2(GetViewportRect().Size.x/2, GetViewportRect().Size.y/2);
        Global.BossLifebar.SetMaxValue(_maxHealthPoint);
        Global.BossLifebar.SetValue(_currentHealthPoint);
    }
    protected void LaunchRandomAoE(int numberOfAoE)
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
            LaunchRandomAoE(1);
        else if (GetHealthPercentage() >= 40)
            LaunchRandomAoE(2);
        else
            LaunchRandomAoE(3);
    }
    public void _OnBlinkTimerTimeout()
    {
        _blink.TriggerBlink();
    }
}
