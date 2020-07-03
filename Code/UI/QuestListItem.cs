using Godot;
using System;

public class QuestListItem : VBoxContainer
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
        _questTitleLabel = GetNode<Label>("QuestTitle");
        _questTitleLabel.Text = _questTitle;
        _mapLabel = GetNode<Label>("Map");
        _mapLabel.Text = _map;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
