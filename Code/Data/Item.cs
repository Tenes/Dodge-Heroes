using Godot;
using System;

public class Item
{
    private string _itemName;
    private Texture _itemTexture;

    public string GetItemName() => _itemName;
    public Texture GetItemTexture() => _itemTexture;

    public Item(string itemName, string itemTexturePath)
    {
        _itemName = itemName;
        _itemTexture = (Texture)GD.Load(itemTexturePath);
    }
}
