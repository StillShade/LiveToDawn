using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    public Inventory inventory;
    public Item bread;
    public Item socks_white;

    void Start()
    {
        inventory.AddItem(bread, 5);
        inventory.AddItem(socks_white, 1);
        inventory.ExpandInventory(5);
        inventory.AddItem(bread, 10);
        inventory.AddItem(socks_white, 1);
        inventory.RemoveItem(bread, 1);
        //inventory.RemoveItem(bread, 14);
        inventory.ExpandInventory(5);
        inventory.ShrinkInventory(5);
    }

    public void RemoveBread()
    {
        inventory.RemoveItem(bread, 1);
    }
}