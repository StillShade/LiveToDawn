using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public Item item;
    
    private int quantity; // Сделали приватным

    public int Quantity => quantity; // Геттер для чтения

    public void SetQuantity(int newQuantity)
    {
        quantity = Mathf.Max(0, newQuantity); // Защита от отрицательных значений
    }

    public InventorySlot()
    {
        item = null;
        quantity = 0;
    }

    public InventorySlot(Item newItem, int newQuantity)
    {
        item = newItem;
        quantity = newQuantity;
    }

    public bool IsEmpty()
    {
        bool isNull = ReferenceEquals(item, null);

        Debug.Log($"Проверка IsEmpty(): item = {(isNull ? "NULL" : item.itemName)}, quantity = {quantity}, результат = {isNull}");

        return isNull;
    }

    public void SetItem(Item newItem, int newQuantity)
    {
        this.item = newItem;
        SetQuantity(newQuantity);
    }

}