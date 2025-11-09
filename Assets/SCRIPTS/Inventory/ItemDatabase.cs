using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Inventory/ItemDatabase")]
    public class ItemDatabase : ScriptableObject
    {
        public List<Item> allItems;

        private Dictionary<string, Item> lookup;

        public void Initialize()
        {
            if (lookup != null) return;

            lookup = new Dictionary<string, Item>();
            foreach (var item in allItems)
            {
                if (item != null && !string.IsNullOrEmpty(item.itemName))
                {
                    lookup[item.itemName] = item;
                }
            }
        }

        public Item GetItemByName(string itemName)
        {
            if (lookup == null)
                Initialize();

            lookup.TryGetValue(itemName, out var item);
            return item;
        }
    }
}
