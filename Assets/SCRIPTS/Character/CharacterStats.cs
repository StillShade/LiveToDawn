using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int armor;
    public int weight;
    public int radiationResistance;
    public int coldResistance;
    public int strength;
    public int damage;
    public int speed;

    public void Add(ItemStats stats)
    {
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
        armor -= stats.armor;
        weight -= stats.weight;
        radiationResistance -= stats.radiationResistance;
        coldResistance -= stats.coldResistance;
        strength -= stats.strength;
        damage -= stats.damage;
        speed -= stats.speed;
    }
}