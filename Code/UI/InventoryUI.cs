using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryUI : Node
{
    private GridContainer _itemGrid;
    private List<int> _itemList;
    private List<int> _AddedItemsId;
    
    public override void _Ready()
    {
        ItemDisplay tempItemDisplay = new ItemDisplay();
        _itemGrid = GetNode<GridContainer>("VBoxContainer/MarginContainer/ScrollContainer/GridContainer");
        _itemList = Global.PlayerData.GetInventory()?.GetItemList();
        _AddedItemsId = new List<int>();
        _itemList?.Sort();
        if(_itemList != null)
        {
            for(int index = 0; index < _itemList.Count; index++)
            {
                if(!_AddedItemsId.Contains(_itemList[index]))
                {
                    Item tempItem = Armory.ItemById[_itemList[index]];
                    tempItemDisplay = (ItemDisplay)Armory.ItemDisplay.Instance();
                    tempItemDisplay.InitializeItemDisplay(tempItem);
                    _itemGrid.AddChild(tempItemDisplay);
                    _AddedItemsId.Add(_itemList[index]);
                }
                else
                {
                    tempItemDisplay.AddToCounter();
                }
            }
        }
    }

    public void _OnExitButtonReleased()
    {
        GetParent().RemoveChild(this);
    }
}
