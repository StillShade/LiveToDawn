using System.Linq;
using UnityEngine;

public class PersonalInventoryUI : MonoBehaviour, IInventoryUI
{
    [SerializeField] public PersonalInventory inventory;
    Inventory IInventoryUI.inventory => inventory; // реализация интерфейса
    [SerializeField] private EquipmentSlotUI[] equipmentSlots; // Назначаются вручную в инспекторе

    private void OnEnable()
    {
        if (inventory == null) return;

        inventory.OnInventoryChanged += UpdateUI;
    }

    private void OnDisable()
    {
        if (inventory == null) return;

        inventory.OnInventoryChanged -= UpdateUI;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            var slotUI = equipmentSlots[i];
            var slot = inventory.equipmentSlots[i]; // Новый метод по индексу
            if (slot != null && !slot.slot.IsEmpty())
            {
                slotUI.SetSlot(slot.slot);
            }
            else
            {
                slotUI.ClearSlot();
            }
        }
    }
}