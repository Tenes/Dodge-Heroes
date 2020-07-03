using Godot;
using System;

public class Lifebar : HBoxContainer
{
    private TextureProgress _filledBar;

    public void SetValue(float value) => _filledBar.Value = value;
    public void SetMaxValue(float value) => _filledBar.MaxValue = value;
    public void UpdateLifeBar(string damageString, bool isCritical)
    {
        _filledBar.Value = Global.CurrentBoss.GetCurrentHealth();
        AddFloatingText(damageString, isCritical);
    }
    public override void _Ready()
    {
        _filledBar = GetNode<TextureProgress>("TextureProgress");
        Global.BossLifebar = this;
    }
    private void AddFloatingText(string text, bool critical)
    {
        FloatingText floatingDamage = (FloatingText)Armory.FloatingText.Instance();
        floatingDamage.SetText(text);
        floatingDamage.SetCriticalValues(critical);
        floatingDamage.GlobalPosition = new Vector2(218 - _filledBar.RectGlobalPosition.x, 80);
        AddChild(floatingDamage);
    }
}
