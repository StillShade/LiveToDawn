using UnityEngine;

public enum ItemType
{
    Weapon,      // Оружие
    Helmet,      // Шлем
    Armor,       // Броня
    Pants,       // Штаны
    Boots,       // Ботинки
    Gloves,      // Перчатки
    Mask,        // Маска
    Backpack,    // Рюкзак
    Socks,       // Носки
    Jacket,      // Куртка
    Sweater,     // Кофта
    TShirt,      // Футболка
    Car,          // Машина
    Food        //еда    
    // Добавить другие типы
}

[System.Serializable]
public struct ItemStats
{
    public int armor;
    public int weight;
    public int radiationResistance;
    public int coldResistance;
    public int strength;
    public int damage;
    public int speed;
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public bool isStackable;
    public int maxStack; // Максимальное количество в стаке

    public ItemType itemType;
    public ItemStats stats;

    public override bool Equals(object obj)
    {
        if (obj is Item otherItem)
        {
            return itemName == otherItem.itemName; // Сравниваем по имени
        }
        return false;
    }

    public override int GetHashCode()
    {
        return itemName.GetHashCode();
    }
}