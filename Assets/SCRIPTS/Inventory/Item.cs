using UnityEngine;

public enum ItemType
{
    Weapon = 0,      // ������
    Helmet = 1,      // ����
    Armor = 2,       // �����
    Pants = 3,       // �����
    Boots = 4,       // �������
    Gloves = 5,      // ��������
    Mask = 6,        // �����
    Backpack = 7,    // ������
    Socks = 8,       // �����
    Jacket = 9,      // ������
    Sweater = 10,     // �����
    TShirt = 11,      // ��������
    Car = 12,          // ������
    Food = 13,       //���
    Glasses = 14,    //����
    Unloading_vest = 15  //���������
    // �������� ������ ����
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
    public int maxStack; // ������������ ���������� � �����

    public ItemType itemType;
    public ItemStats stats;

    public override bool Equals(object obj)
    {
        if (obj is Item otherItem)
        {
            return itemName == otherItem.itemName; // ���������� �� �����
        }
        return false;
    }

    public override int GetHashCode()
    {
        return (itemName != null ? itemName.GetHashCode() : 0);
    }
}