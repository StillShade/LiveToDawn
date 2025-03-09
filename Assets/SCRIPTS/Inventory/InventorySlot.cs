[System.Serializable]
public class InventorySlot
{
	public Item item;
	public int quantity;

	public InventorySlot(Item newItem, int newQuantity)
	{
		item = newItem;
		quantity = newQuantity;
	}

	public void AddAmount(int amount)
	{
		quantity += amount;
	}
}