using Godot;
using System.Collections.Generic;

public class LootDisplay : ColorRect
{
    private GridContainer _lootGrid;
    public override void _Ready()
    {
        _lootGrid = GetNode<GridContainer>("VBoxContainer/GridContainer");
        List<int> lootList = Armory.LootTablePerBoss[Global.CurrentBoss.GetTitle()];
        ItemDisplay tempItemDisplay;
        Inventory playerInventory = Global.PlayerData.GetInventory();
        for(int index = 0; index < lootList.Count; index++)
        {
            tempItemDisplay = (ItemDisplay)Armory.ItemDisplay.Instance();
            Item tempItem = Armory.ItemById[lootList[index]];
            tempItemDisplay.InitializeItemDisplay(tempItem);
            _lootGrid.AddChild(tempItemDisplay);
            playerInventory.AddItem(lootList[index]);
        }
    }

    public void _OnExitButtonReleased()
    {
        SceneTree tree = GetTree();
        tree.ChangeSceneTo(Armory.CityScene);
    }
}
