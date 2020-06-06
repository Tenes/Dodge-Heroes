public enum Classes {Warrior, Archer, Mage};

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
    public Classes GetClassFlag() => this._classFlag;
    public float GetDamage() => this._baseDamage * this._damageModifier;
    public string GetDamagePercentage() => (this._damageModifier * 100).ToString();
    public float GetMovespeed() => this._baseMovespeed * this._movespeedModifier;
    public string GetMovespeedPercentage() => (this._movespeedModifier * 100).ToString();
    public float GetAttackspeed() => this._baseAttackspeed * (1/this._attackspeedModifier);
    public string GetAttackspeedPercentage() => (this._attackspeedModifier * 100).ToString();
    public float GetChanceToDropItemAndMaterials() => this._baseChanceToDropItemAndMaterials * this._chanceToDropItemAndMaterialsModifier;
    public string GetChanceToDropItemAndMaterialsPercentage() => (this._chanceToDropItemAndMaterialsModifier * 100).ToString();
    public float GetCritDamage() => this._baseCritDamage * this._critDamageModifier;
    public string GetCritDamagePercentage() => (this._critDamageModifier * 100).ToString();
    public float GetCritChance() => this._baseCritChance * this._critChanceModifier;
    public string GetCritChancePercentage() => (this._critChanceModifier * 100).ToString();
}
