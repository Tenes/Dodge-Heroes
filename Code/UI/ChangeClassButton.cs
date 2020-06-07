using Godot;

public class ChangeClassButton : TextureButton
{
    private static Player _player;
    private static ActualClassSprite _currentClass;
    private Sprite _classIcon;
    private Classes _classHeld;
    public void SetClassHeld(Classes classHeld) => this._classHeld = classHeld;

    public override void _Ready()
    {
        _player = GetNode<Player>("/root/Combat/Player");
        _currentClass = GetNode<ActualClassSprite>("/root/Combat/UI/CurrentClass");
        this._classIcon = GetNode<Sprite>("Icon");
    }
    public override void _GuiInput(InputEvent @event)
    {
        if (@event is InputEventScreenTouch inputEventScreenTouch && inputEventScreenTouch.Pressed)
        {
            ChangePlayerClassAndUpdateButtons(_classHeld);
        }
    }
    public void ChangePlayerClassAndUpdateButtons(Classes newClass)
    {
        this._classHeld = _player.GetClassFlag();
        this._classIcon.RegionRect = Armory.ClassesButtonRegion[_player.GetClassFlag()];
        _player.SetClass(newClass);
        _currentClass.SetIconForClass(newClass);
    }

}
