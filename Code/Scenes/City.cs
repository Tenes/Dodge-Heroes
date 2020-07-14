using Godot;
using System;

public class City : Node2D
{
    private float _timerForGarbageCollection = 0;
    private float _timeToHit = 20f;
    private InventoryUI _inventoryUi;
    private QuestBoard _questBoard;
    private Label _characterGold;
    private Label _characterPseudo;
    private bool WindowOpened() => GetNodeOrNull("QuestBoard") == null && GetNodeOrNull("Inventory") == null && GetNodeOrNull("Blacksmith") == null;
    public override void _Ready()
    {
        Global.PlayerData.Serialize();
        _inventoryUi = (InventoryUI)Armory.InventoryUI.Instance();
        _questBoard = (QuestBoard)Armory.QuestBoard.Instance();
        _characterGold = GetNode<Label>("UI/TopContainer/HBoxContainer/Gold");
        _characterPseudo = GetNode<Label>("UI/TopContainer/Pseudo");
        _characterGold.Text = Global.PlayerData.GetMoney().ToString();
        _characterPseudo.Text = Global.PlayerData.GetPseudo();
    }

    public override void _Process(float delta)
    {
        _timerForGarbageCollection += delta;
        if(_timerForGarbageCollection >= _timeToHit)
        {
            GC.Collect(0);
            GC.WaitForPendingFinalizers();
            _timerForGarbageCollection= 0;
        }
    }
    public void _OnQuestBoardButtonReleased()
    {
        if(WindowOpened())
            AddChild(_questBoard);
    }

    public void _OnInventoryButtonReleased()
    {
        if(WindowOpened())
            AddChild(_inventoryUi);
    }
}
