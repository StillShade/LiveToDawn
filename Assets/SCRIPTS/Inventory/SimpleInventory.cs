using UnityEngine;

namespace Inventory
{
    public class SimpleInventory : Inventory
    {
        private void Start()
        {
            Debug.Log("SimpleInventory инициализирован.");
        }

        public override bool TryEquip(Item item)
        {
            // В обычном инвентаре экипировка не поддерживается
            Debug.LogWarning("Нельзя экипировать предмет в SimpleInventory.");
            return false;
        }
    }
}