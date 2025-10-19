using UnityEngine;

public enum ItemType
{
    Weapon = 0,      // Оружие
    Helmet = 1,      // Шлем
    Armor = 2,       // Броня
    Pants = 3,       // Штаны
    Boots = 4,       // Ботинки
    Gloves = 5,      // Перчатки
    Mask = 6,        // Маска
    Backpack = 7,    // Рюкзак
    Socks = 8,       // Носки
    Jacket = 9,      // Куртка
    Sweater = 10,     // Кофта
    TShirt = 11,      // Футболка
    Car = 12,          // Машина
    Food = 13,       //еда
    Glasses = 14,    //очки
    Unloading_vest = 15, //разгрузка
    Clock = 16, //часы
    Underwear = 17, //нижнее белье
    GPS = 18,
    Flashlight = 19, //фонарик

    // Добавить другие типы
}

[System.Serializable]
public struct ItemStats
{
    public int inventorySlotsCount;
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
        return (itemName != null ? itemName.GetHashCode() : 0);
    }
}