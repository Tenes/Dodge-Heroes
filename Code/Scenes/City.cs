using Godot;
using System;

public class City : Node2D
{
    private QuestBoard _questBoard;
    private Label _characterGold;
    private Label _characterPseudo;
    public override void _Ready()
    {
        Global.PlayerData.Serialize();
        _questBoard = (QuestBoard)Armory.QuestBoard.Instance();
        _characterGold = GetNode<Label>("UI/TopContainer/HBoxContainer/Gold");
        _characterPseudo = GetNode<Label>("UI/TopContainer/Pseudo");
        _characterGold.Text = Global.PlayerData.GetMoney().ToString();
        _characterPseudo.Text = Global.PlayerData.GetPseudo();
    }
    public void _OnQuestPanelReleased()
    {
        if(GetNodeOrNull("QuestBoard") == null)
            AddChild(_questBoard);
    }

}
