using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory
{
    public class EquipmentSlotUI : InventorySlotUI, IPointerClickHandler
    {
        public ItemType acceptedType;
        public override ItemType? AcceptedType => acceptedType;
        private PersonalInventoryUI personalInventoryUI;
        public override bool IsEquipmentSlot => true;
        [SerializeField] private Sprite defaultIcon;

        private void Start()
        {
            personalInventoryUI = GetComponentInParent<PersonalInventoryUI>();
            if (personalInventoryUI == null)
            {
                Debug.LogError("❌ EquipmentSlotUI: Не найден PersonalInventoryUI в родителях!");
            }
        }

        public override void OnDrop(PointerEventData eventData)
        {
            // ✅ Используем защищённое свойство Slot вместо прямого доступа к полю
            if (draggedSlot == null || draggedSlot.Slot == null || draggedSlot.Slot.item == null)
                return;
            Debug.Log($"Перемещение предмета {draggedSlot.Slot.item.itemName} в новый слот в Экипировку");

            SwapItems(draggedSlot, sourceInventoryUI);
        }

        public override void ClearSlot()
        {
            Slot = null;

            if (itemIcon != null)
            {
                itemIcon.sprite = defaultIcon;
                itemIcon.enabled = true;
                //itemIcon.color = new Color(1f, 1f, 1f, 0.5f); // полупрозрачная, если хочешь
            }

            if (quantityText != null)
            {
                quantityText.text = "";
            }

        }

        public override void SetSlot(InventorySlot newSlot)
        {
            base.SetSlot(newSlot);

            // Можно добавить отображение типа, если слот пуст (например, иконка шлема)
            if ((newSlot == null || newSlot.item == null) && itemIcon != null)
            {
                itemIcon.sprite = GetPlaceholderIconForType(acceptedType);
                itemIcon.color = new Color(1f, 1f, 1f, 0.5f); // Полупрозрачная иконка, показывающая тип
            }
        }

        private Sprite GetPlaceholderIconForType(ItemType type)
        {
            // Можно привязать через ScriptableObject или Resources.Load
            return null;
        }
            // для слота с оружием - атака
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Клик по кнопке для атаки");
            if (Slot == null)
            {
                Debug.LogWarning("Slot is null!");
                return;
            }
            if (Slot.item == null)
            {
                Debug.LogWarning("Slot.item is null!");
                return;
            }
            if (AttackManager.Instance == null)
            {
                Debug.LogWarning("AttackManager.Instance is null!");
                return;
            }
            if (Slot.item.itemType != ItemType.Weapon)
            {
                Debug.LogWarning("В слоте не оружие!");
                return;
            }

            AttackManager.Instance.AttackWithWeapon(Slot.item);
        }
    }
}

