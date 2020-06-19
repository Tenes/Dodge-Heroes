using System.Collections.Generic;
using Godot;

public enum Classes { Warrior, Archer, Mage };

public abstract class BaseClass
{
    //Stats
    protected Classes _classFlag;
    protected float _baseDamage = 1;
    protected float _damageModifier = 1f;
    protected float _baseMovespeed = 200;
    protected float _movespeedModifier = 1f;
    protected float _baseAttackspeed = 0.5f;
    protected float _attackspeedModifier = 1f;
    protected float _baseChanceToDropItemAndMaterials = 1f;
    protected float _chanceToDropItemAndMaterialsModifier = 1f;
    protected float _baseCritDamage = 1.5f;
    protected float _critDamageModifier = 1f;
    protected float _baseCritChance = 0.1f;
    protected float _critChanceModifier = 1f;
    public Classes GetClassFlag() => _classFlag;

    public float GetDamage() => _baseDamage * _damageModifier;
    public string GetDamagePercentage() => (_damageModifier * 100).ToString();
    public float GetCriticalHitDamage() => _baseDamage * _damageModifier * GetCritDamage();
    public float GetMovespeed() => _baseMovespeed * _movespeedModifier;
    public string GetMovespeedPercentage() => (_movespeedModifier * 100).ToString();
    public float GetAttackspeed() => _baseAttackspeed * (1 / _attackspeedModifier);
    public string GetAttackspeedPercentage() => (_attackspeedModifier * 100).ToString();
    public float GetChanceToDropItemAndMaterials() => _baseChanceToDropItemAndMaterials * _chanceToDropItemAndMaterialsModifier;
    public string GetChanceToDropItemAndMaterialsPercentage() => (_chanceToDropItemAndMaterialsModifier * 100).ToString();
    public float GetCritDamage() => _baseCritDamage * _critDamageModifier;
    public string GetCritDamagePercentage() => (_critDamageModifier * 100).ToString();
    public float GetCritChance() => _baseCritChance * _critChanceModifier;
    public string GetCritChancePercentage() => (_critChanceModifier * 100).ToString();
    public (float damage, bool isCritical) Hit()
    {
        if (Global.Rng.Next(0, 101) >= 100 - (GetCritChance() * 100))
            return (GetCriticalHitDamage(), true);
        else
            return (GetDamage(), false);
    }
}
