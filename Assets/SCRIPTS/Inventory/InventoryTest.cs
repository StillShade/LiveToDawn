using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    public Inventory inventory;
    public Inventory inventory2;
    public Item bread;
    public Item socks_white;

    void Start()
    {
        inventory2.AddItemToSlot(0, socks_white, 1);
        inventory.AddItemToSlot(0, socks_white, 1);
        inventory.AddItem(bread, 5);
        inventory.AddItem(socks_white, 1);
        inventory.ExpandInventory(5);
        inventory.AddItem(bread, 10);
        inventory.AddItem(socks_white, 1);
        inventory.RemoveItem(bread, 1);
        //inventory.RemoveItem(bread, 14);
        //inventory.ExpandInventory(5);
        //inventory.ShrinkInventory(5);
        inventory.AddItem(socks_white, 1);
        inventory.AddItem(socks_white, 1);
        inventory.AddItem(socks_white, 1);
        inventory.AddItem(socks_white, 1);
        inventory.AddItem(socks_white, 1);
        inventory.AddItem(socks_white, 1);
        //inventory.RemoveItemFromSlot(0, 1);
    }

    public void RemoveBread()
    {
        inventory.RemoveItem(bread, 1);
    }
}