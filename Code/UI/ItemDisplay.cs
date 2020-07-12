using Godot;
using System;

public class ItemDisplay : TextureRect
{
    private string _itemName;
    private TextureRect _itemIcon;
    private Texture _itemTexture;
    public void InitializeItemDisplay(Item item)
    {
        _itemName = item.GetItemName();
        _itemTexture = item.GetItemTexture();
    }
    public override void _Ready()
    {
        _itemIcon = GetNode<TextureRect>("ItemIcon");
        _itemIcon.Texture = _itemTexture;
    }

}
