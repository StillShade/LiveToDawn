using UnityEngine;

public class PersonalInventoryUI : MonoBehaviour, IInventoryUI
{
    [SerializeField] public PersonalInventory inventory;
    Inventory IInventoryUI.inventory => inventory; // ���������� ����������
    [SerializeField] private EquipmentSlotUI[] equipmentSlots; // ����������� ������� � ����������

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
        foreach (var slotUI in equipmentSlots)
        {
            var slot = inventory.GetEquipmentSlot(slotUI.acceptedType);
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