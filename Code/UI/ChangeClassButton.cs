using Godot;

public class ChangeClassButton : TextureButton
{
    private static Player _player;
    private static ActualClassSprite _currentClass;
    private Sprite _classIcon;
    private Classes _classHeld;
    private Timer _changeTimer;
    private TimerLabel _timerLabel;
    private Color _normalColor;
    private Color _tintedColor;
    private void SwitchState() => Disabled = !Disabled;
    public void SetClassHeld(Classes classHeld) => _classHeld = classHeld;

    public override void _Ready()
    {
        _player = GetNode<Player>("/root/Combat/Player");
        _currentClass = GetNode<ActualClassSprite>("/root/Combat/UI/CurrentClass");
        _classIcon = GetNode<Sprite>("Icon");
        _changeTimer = GetNode<Timer>("Timer");
        _timerLabel = GetNode<TimerLabel>("Timer/Label");
        _normalColor = new Color(1, 1, 1, 1);
        _tintedColor = new Color(0.4f, 0.4f, 0.4f, 1);
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
        _timerLabel.SwitchHideVisible();
        Modulate = _tintedColor;
    }
    public void _OnTimerTimeout()
    {
        SwitchState();
        _timerLabel.SwitchHideVisible();
        Modulate = _normalColor;
    }
}
