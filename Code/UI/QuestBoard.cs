using Godot;
using System;

public class QuestBoard : ColorRect
{
    private VBoxContainer _vboxContainer;
    public override void _Ready()
    {
        _vboxContainer = GetNode<VBoxContainer>("ScrollContainer/VBoxContainer");
        foreach(PackedScene boss in Armory.Bosses)
        {
            Boss tempBoss = (Boss)boss.Instance();
            QuestListItem tempQuest = (QuestListItem)Armory.QuestListItem.Instance();
            tempQuest.SetQuestTitle(tempBoss.GetTitle());
            tempQuest.SetMapName("Floating Platform");
            tempQuest.SetTargetBoss(tempBoss);
            _vboxContainer.AddChild(tempQuest);
        }
    }

    public void _OnExitButtonReleased()
    {
        GetParent().RemoveChild(this);
    }
}
