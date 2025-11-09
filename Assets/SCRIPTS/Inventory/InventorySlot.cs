using UnityEngine;

namespace Inventory
{
    [System.Serializable]
    public class InventorySlot
    {
        public Item item;
        private int quantity; // ������� ���������

        public int Quantity => quantity; // ������ ��� ������

        public void SetQuantity(int newQuantity)
        {
            quantity = Mathf.Max(0, newQuantity); // ������ �� ������������� ��������
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

            Debug.Log($"�������� IsEmpty(): item = {(isNull ? "NULL" : item.itemName)}, quantity = {quantity}, ��������� = {isNull}");

            return isNull;
        }

        public void SetItem(Item newItem, int newQuantity)
        {
            this.item = newItem;
            SetQuantity(newQuantity);
        }

        public void Clear()
        {
            item = null;
            quantity = 0;
        }
    }
}

