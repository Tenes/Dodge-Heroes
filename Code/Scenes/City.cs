using Godot;
using System;

public class City : Node2D
{
    private QuestBoard _questBoard;
    public override void _Ready()
    {
        _questBoard = (QuestBoard)Armory.QuestBoard.Instance();
    }
    public void _OnQuestPanelReleased()
    {
        if(GetNodeOrNull("QuestBoard") == null)
            AddChild(_questBoard);
    }

}
