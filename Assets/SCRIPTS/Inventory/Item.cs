using UnityEngine;

public enum ItemType
{
    Weapon,      // ������
    Helmet,      // ����
    Armor,       // �����
    Pants,       // �����
    Boots,       // �������
    Gloves,      // ��������
    Mask,        // �����
    Backpack,    // ������
    Socks,       // �����
    Jacket,      // ������
    Sweater,     // �����
    TShirt,      // ��������
    Car,          // ������
    Food        //���    
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
        return itemName.GetHashCode();
    }
}