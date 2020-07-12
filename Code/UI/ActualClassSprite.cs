using Godot;
using System;

public class ActualClassSprite : TextureRect
{
    private TextureRect _iconSprite;
    public Texture GetClassIcon() => _iconSprite.Texture;
    public void SetIconForClass(Classes actualClass) => _iconSprite.Texture = Armory.ClassesIcons[actualClass];
    
    public override void _Ready()
    {
        _iconSprite = GetNode<TextureRect>("Icon");
    }
}
