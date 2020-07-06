using Godot;

public class DragonBoss : Boss
{
    public DragonBoss()
    {
        _title = "Dragon";
        _maxHealthPoint = 180;
        _currentHealthPoint = 180;
        _moneyValue = 100;
        _bossAoEs = new PackedScene[]
        {
            Armory.AoEsByName["AoEH"],
            Armory.AoEsByName["AoE4Squares"],
            Armory.AoEsByName["AoEBarcode"],
            Armory.AoEsByName["AoE3Circles"],
            Armory.AoEsByName["AoE3CirclesVariant"],
            Armory.AoEsByName["AoEDoughnutH"],
            Armory.AoEsByName["AoEDoughnutV"]
        };
    }
}
