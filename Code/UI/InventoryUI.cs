using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryUI : Node
{
    private GridContainer _itemGrid;
    private List<int> _itemList;
    
    public override void _Ready()
    {
        _itemGrid = GetNode<GridContainer>("VBoxContainer/MarginContainer/ScrollContainer/GridContainer");
        _itemList = Global.PlayerData.GetInventory()?.GetItemList();
        ItemDisplay tempItemDisplay;
        if(_itemList != null)
        {
            for(int index = 0; index < _itemList.Count; index++)
            {
                tempItemDisplay = (ItemDisplay)Armory.ItemDisplay.Instance();
                Item tempItem = Armory.ItemById[_itemList[index]];
                tempItemDisplay.InitializeItemDisplay(tempItem);
                _itemGrid.AddChild(tempItemDisplay);
            }
        }
    }

    public void _OnExitButtonReleased()
    {
        GetParent().RemoveChild(this);
    }
}
