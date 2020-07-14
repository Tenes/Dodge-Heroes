using Godot;
using System.Collections.Generic;

public class LootDisplay : ColorRect
{
    private GridContainer _lootGrid;
    private List<int> _addedLootItemsId;
    public override void _Ready()
    {
        List<int> lootList = Armory.GetRandomLootByBoss(Global.Player.GetCurrentClass().GetChanceToDropItemAndMaterials(), Global.CurrentBoss.GetTitle());
        ItemDisplay tempItemDisplay = new ItemDisplay();
        Inventory playerInventory = Global.PlayerData.GetInventory();
        _lootGrid = GetNode<GridContainer>("VBoxContainer/MarginContainer/GridContainer");
        _addedLootItemsId = new List<int>();
        lootList.Sort();
        for(int index = 0; index < lootList.Count; index++)
        {
            if(!_addedLootItemsId.Contains(lootList[index]))
            {
                Item tempItem = Armory.ItemById[lootList[index]];
                tempItemDisplay = (ItemDisplay)Armory.ItemDisplay.Instance();
                tempItemDisplay.InitializeItemDisplay(tempItem);
                _lootGrid.AddChild(tempItemDisplay);
                _addedLootItemsId.Add(lootList[index]);
            }
            else
            {
                tempItemDisplay.AddToCounter();
            }
            playerInventory.AddItem(lootList[index]);
        }
    }

    public void _OnExitButtonReleased()
    {
        SceneTree tree = GetTree();
        tree.ChangeSceneTo(Armory.CityScene);
    }
}
