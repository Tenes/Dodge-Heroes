using Godot;

public class ChangeClassButton : TextureButton
{
    private static Player _player;
    private static ActualClassSprite _currentClass;
    private static int _cooldown = 5;
    private Sprite _classIcon;
    private Classes _classHeld;
    private Timer _changeTimer;
    private TimerLabel _timerLabel;
    private TextureProgress _radialSwipe;
    private void SwitchState() => Disabled = !Disabled;
    public void SetClassHeld(Classes classHeld) => _classHeld = classHeld;

    public override void _Ready()
    {
        _player = GetNode<Player>("/root/Combat/Player");
        _currentClass = GetNode<ActualClassSprite>("/root/Combat/UI/CurrentClass");
        _classIcon = GetNode<Sprite>("Icon");
        _changeTimer = GetNode<Timer>("Timer");
        _changeTimer.WaitTime = _cooldown;
        _timerLabel = GetNode<TimerLabel>("Timer/Label");
        _radialSwipe = GetNode<TextureProgress>("TextureProgress");
        _radialSwipe.TextureProgress_ = TextureNormal;
        _radialSwipe.Value = 0;
        SetProcess(false);
    }
    public override void _GuiInput(InputEvent @event)
    {
        if (!Disabled && @event is InputEventScreenTouch inputEventScreenTouch && inputEventScreenTouch.Pressed)
        {
            ChangePlayerClassAndUpdateButtons(_classHeld);
        }
    }
    public void ChangePlayerClassAndUpdateButtons(Classes newClass)
    {
        _classHeld = _player.GetClassFlag();
        _classIcon.RegionRect = Armory.ClassesButtonRegion[_player.GetClassFlag()];
        _player.SetClass(newClass);
        _currentClass.SetIconForClass(newClass);
        _changeTimer.Start();
        SwitchState();
        _timerLabel.Show();
        SetProcess(true);
    }
    public override void _Process(float delta)
    {
        _radialSwipe.Value = (int)((_changeTimer.TimeLeft / _cooldown) * 100);
    }

    public void _OnTimerTimeout()
    {
        SwitchState();
        _timerLabel.Hide();
        _radialSwipe.Value = 0;
        SetProcess(false);
    }
}
