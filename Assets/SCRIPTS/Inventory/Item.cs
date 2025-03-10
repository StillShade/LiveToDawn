using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public bool isStackable;
    public int maxStack; // ������������ ���������� � �����

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