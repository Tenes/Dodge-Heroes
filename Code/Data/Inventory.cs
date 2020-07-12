using Godot;
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Inventory
{
    [JsonProperty(PropertyName = "Items")]
    private List<int> _itemsList;
    public List<int> GetItemList() => _itemsList;
    public void AddItem(int id) => _itemsList.Add(id);
    public void RemoveItem(int id) => _itemsList.Remove(id);
    public Inventory()
    {
        _itemsList = new List<int>();
    }
}
