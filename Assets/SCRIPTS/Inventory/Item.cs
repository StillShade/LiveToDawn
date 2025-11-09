using System.Collections.Generic;
using Character;
using UnityEngine;

public enum ItemType
{
    Weapon = 0,      // ??????
    Helmet = 1,      // ????
    Armor = 2,       // ?????
    Pants = 3,       // ?????
    Boots = 4,       // ???????
    Gloves = 5,      // ????????
    Mask = 6,        // ?????
    Backpack = 7,    // ??????
    Socks = 8,       // ?????
    Jacket = 9,      // ??????
    Sweater = 10,     // ?????
    TShirt = 11,      // ????????
    Car = 12,          // ??????
    Food = 13,       //???
    Glasses = 14,    //????
    Unloading_vest = 15, //?????????
    Clock = 16, //????
    Underwear = 17, //?????? ?????
    GPS = 18,
    Flashlight = 19, //???????

    // ???????? ?????? ????
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public bool isStackable;
    public int maxStack;

    public ItemType itemType;

    [Header("Инвентарь и вес")]
    public int inventorySlotsCount;
    public int weight;

    [Header("Характеристики")]
    public List<StatEntry> stats = new();

    public Dictionary<CharacterStatType, int> GetStatModifiers()
    {
        Dictionary<CharacterStatType, int> result = new();
        foreach (var entry in stats)
        {
            if (result.ContainsKey(entry.stat))
                result[entry.stat] += entry.value;
            else
                result[entry.stat] = entry.value;
        }
        return result;
    }

    public override bool Equals(object obj)
    {
        if (obj is Item otherItem)
        {
            return itemName == otherItem.itemName;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return (itemName != null ? itemName.GetHashCode() : 0);
    }
}