using System.ComponentModel;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    public Inventory inventory;
    public Inventory inventory2;
    public Item bread;
    public Item socks_white;
    public Item socks_red;
    public Item knife;
    public Item topor;
    public Item kirka;
    public Item pistolet;

    

    void Start()
    {
        TargetType[] allTypes = (TargetType[])System.Enum.GetValues(typeof(TargetType));
        // Выбираем случайный индекс
        TargetType randomType = allTypes[Random.Range(0, allTypes.Length)];
        //вызываем уничтожаемый объект
        DamageableObjectFactory.Instance.CreateRandom(randomType, new Vector3(0, 0, 0));

        inventory2.AddItemToSlot(0, socks_white, 1);
        inventory.AddItemToSlot(0, socks_white, 1);
        inventory.AddItem(bread, 5);
        inventory.AddItem(socks_white, 1);
        inventory.ExpandInventory(5);
        inventory.AddItem(bread, 10);
        inventory.AddItem(socks_white, 1);
        inventory.RemoveItem(bread, 1);
        inventory.AddItem(knife, 1);
        //inventory.RemoveItem(bread, 14);
        //inventory.ExpandInventory(5);
        //inventory.ShrinkInventory(5);
        inventory.AddItem(socks_white, 1);
        inventory.AddItem(pistolet, 1);
        inventory.AddItem(socks_white, 1);
        inventory.AddItem(topor, 1);
        inventory.AddItem(kirka, 1);
        inventory.AddItem(socks_red, 1);
        //inventory.RemoveItemFromSlot(0, 1);
    }

    public void RemoveBread()
    {
        inventory.RemoveItem(bread, 1);
    }
}