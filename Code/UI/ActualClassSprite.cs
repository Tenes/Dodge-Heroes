using Godot;
using System;

public class ActualClassSprite : Sprite
{
    private Sprite _iconSprite;
    public Texture GetClassIcon() => this._iconSprite.Texture;
    public void SetIconForClass(Classes actualClass) => this._iconSprite.RegionRect = Armory.ClassesButtonRegion[actualClass];
    
    public override void _Ready()
    {
        this._iconSprite = GetNode<Sprite>("Icon");
    }
}
