using Godot;

public class ChangeClassButton : TextureButton
{
    private static Player _player;

    public override void _Ready()
    {
        _player = GetNode<Player>("/root/Combat/Player");
    }
    public override void _GuiInput(InputEvent @event)
    {
        if (@event is InputEventScreenTouch mbe && mbe.Pressed)
        {
            switch(this.Name)
            {
                case "WarriorButton":
                    _player.SetClass(Classes.Warrior);
                    break;
                case "ArcherButton":
                    _player.SetClass(Classes.Archer);
                    break;
                case "MageButton":
                    _player.SetClass(Classes.Mage);
                    break;
            }
        }
    }

}
