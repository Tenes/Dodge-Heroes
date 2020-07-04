using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class PlayerData
{
    private string _pseudo;
    private int _money;
    private Inventory _inventory;

    public void SetPseudo(string pseudo) => _pseudo = pseudo;
    public void AddMoney(int amount) => _money += amount;
    public void SubstractMoney(int amount) => _money -= amount;

    public string GetPseudo() => _pseudo;
    public int GetMoney() => _money;
    public Inventory GetInventory() => _inventory;

    public PlayerData(string pseudo, int money)
    {
        _pseudo = pseudo;
        _money = money;
    }
}
