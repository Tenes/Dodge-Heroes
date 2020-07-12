using Newtonsoft.Json;
using File = System.IO.File;

public class PlayerData
{
    [JsonProperty(PropertyName = "Pseudo")]
    private string _pseudo;
    [JsonProperty(PropertyName = "Money")]
    private int _money;
    [JsonProperty(PropertyName = "Inventory")]
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
        _inventory = new Inventory();
    }
    public void Serialize()
    {
        File.WriteAllText(@"./data.json", JsonConvert.SerializeObject(this));
    }
}
