using Godot;
using System;

public class ItemDisplay : TextureRect
{
    private string _itemName;
    private TextureRect _itemIcon;
    private Label _itemCount;
    private Texture _itemTexture;
    public void AddToCounter() => _itemCount.Text = (int.Parse(_itemCount.Text) + 1).ToString();
    public void InitializeItemDisplay(Item item)
    {
        _itemName = item.GetItemName();
        _itemTexture = item.GetItemTexture();
    }
    public override void _Ready()
    {
        _itemIcon = GetNode<TextureRect>("ItemIcon");
        _itemCount = GetNode<Label>("ItemCount");
        _itemIcon.Texture = _itemTexture;
    }

}
