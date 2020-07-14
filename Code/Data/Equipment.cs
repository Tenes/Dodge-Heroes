using Godot;
using System;

public enum Rarity {COMMON, UNCOMMON, RARE, LEGENDARY};
public class Equipment : Item
{
    private Rarity _itemRarity;
    protected float _damageModifier = 1f;
    protected float _movespeedModifier = 1f;
    protected float _attackspeedModifier = 1f;
    protected float _chanceToDropItemAndMaterialsModifier = 1f;
    protected float _critDamageModifier = 1f;
    protected float _critChanceModifier = 1f;
    public Equipment(string itemName, string itemTexturePath)
        : base(itemName, itemTexturePath)
    {
    }
}
