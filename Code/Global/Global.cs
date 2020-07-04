using Godot;
using System;

public static class Global
{
    public static Player Player;
    public static PlayerData PlayerData = new PlayerData("Feffhe", 1000);
    public static Boss CurrentBoss;
    public static Lifebar BossLifebar;
    public static PlayerHealth PlayerHealthUI;
    public static Random Rng = new Random();
}
