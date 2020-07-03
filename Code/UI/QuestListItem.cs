using Godot;
using System;

public class QuestListItem : HBoxContainer
{
    private string _questTitle;
    private string _map;
    private Label _questTitleLabel;
    private Label _mapLabel;
    private Boss _targetBoss;
    public void SetQuestTitle(string title) => _questTitle = title;
    public void SetMapName(string name) => _map = name;
    public void SetTargetBoss(Boss boss) => _targetBoss = boss;
    
    public override void _Ready()
    {
        _questTitleLabel = GetNode<Label>("VBoxContainer/QuestTitle");
        _questTitleLabel.Text = _questTitle;
        _mapLabel = GetNode<Label>("VBoxContainer/Map");
        _mapLabel.Text = _map;
        Global.CurrentBoss = _targetBoss;
    }
    public void _OnHuntButtonReleased()
    {
        SceneTree tree = GetTree();
        tree.ChangeSceneTo(Armory.CombatScene);
    }
}
