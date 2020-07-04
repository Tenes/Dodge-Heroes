using Godot;
using System;

public class ActualClassSprite : Sprite
{
    private Sprite _iconSprite;
    public Texture GetClassIcon() => _iconSprite.Texture;
    public void SetIconForClass(Classes actualClass) => _iconSprite.Texture = Armory.ClassesIcons[actualClass];
    
    public override void _Ready()
    {
        _iconSprite = GetNode<Sprite>("Icon");
    }
}
