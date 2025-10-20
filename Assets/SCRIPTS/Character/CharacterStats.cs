using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    private int inventorySlotsCount = 2;
    public int InventorySlotsCount => inventorySlotsCount;
    public int armor;
    public int weight;
    public int radiationResistance;
    public int coldResistance;
    public int strength;
    public int damage;
    public int speed;

    public event Action<int> OnInventorySlotsChanged;
    
    public void Add(ItemStats stats)
    {
        if (stats.inventorySlotsCount != 0)
        {
            inventorySlotsCount += stats.inventorySlotsCount;
            OnInventorySlotsChanged?.Invoke(stats.inventorySlotsCount);
        }
        armor += stats.armor;
        weight += stats.weight;
        radiationResistance += stats.radiationResistance;
        coldResistance += stats.coldResistance;
        strength += stats.strength;
        damage += stats.damage;
        speed += stats.speed;
    }

    public void Remove(ItemStats stats)
    {
        if (stats.inventorySlotsCount != 0)
        {
            inventorySlotsCount -= stats.inventorySlotsCount;
            OnInventorySlotsChanged?.Invoke(-stats.inventorySlotsCount);
        }
        armor -= stats.armor;
        weight -= stats.weight;
        radiationResistance -= stats.radiationResistance;
        coldResistance -= stats.coldResistance;
        strength -= stats.strength;
        damage -= stats.damage;
        speed -= stats.speed;
    }
}