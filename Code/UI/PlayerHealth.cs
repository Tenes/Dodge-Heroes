using Godot;
using System;

public class PlayerHealth : VBoxContainer
{
    private TextureRect _firstHeart;
    private TextureRect _secondHeart;
    private TextureRect _thirdHeart;
    public override void _Ready()
    {
        _firstHeart = GetNode<TextureRect>("FirstHeart");
        _secondHeart = GetNode<TextureRect>("SecondHeart");
        _thirdHeart = GetNode<TextureRect>("ThirdHeart");
        Global.PlayerHealthUI = this;
    }

    public void UpdateUI(byte currentHealth)
    {
        switch(currentHealth)
        {
            case 0:
                _firstHeart.Texture = Armory.UITextures["HeartEmpty"];
                _secondHeart.Texture = Armory.UITextures["HeartEmpty"];
                _thirdHeart.Texture = Armory.UITextures["HeartEmpty"];
                break;
            case 1:
                _firstHeart.Texture = Armory.UITextures["HeartFull"];
                _secondHeart.Texture = Armory.UITextures["HeartEmpty"];
                _thirdHeart.Texture = Armory.UITextures["HeartEmpty"];
                break;
            case 2:
                _firstHeart.Texture = Armory.UITextures["HeartFull"];
                _secondHeart.Texture = Armory.UITextures["HeartFull"];
                _thirdHeart.Texture = Armory.UITextures["HeartEmpty"];
                break;
            case 3:
                _firstHeart.Texture = Armory.UITextures["HeartFull"];
                _secondHeart.Texture = Armory.UITextures["HeartFull"];
                _thirdHeart.Texture = Armory.UITextures["HeartFull"];
                break;
        }
    }
}
