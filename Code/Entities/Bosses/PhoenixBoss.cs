using Godot;

public class PhoenixBoss : Boss
{
    public PhoenixBoss()
    {
        _title = "Phoenix";
        _maxHealthPoint = 230;
        _currentHealthPoint = 230;
        _moneyValue = 200;
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
