using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Inventory
{
        [System.Serializable]
    public struct RectTransformState
    {
        public Vector2 anchorMin;
        public Vector2 anchorMax;
        public Vector2 anchoredPosition;
        public Vector2 sizeDelta;
        public Vector2 pivot;
        public Quaternion rotation;
        public Vector3 scale;
    }

    public class InventorySlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        public Image itemIcon;  // Иконка предмета
        public Text quantityText; // Количество предметов

        private InventorySlot slot;
        public InventorySlot Slot
        {
            get => slot;
            set => slot = value;
        } // Ссылка на слот инвентаря
        private Transform originalParent; // Для возврата иконки
        protected static InventorySlotUI draggedSlot; // Какой слот перетаскиваем

        public virtual bool IsEquipmentSlot => false;

        private Texture2D dragCursorTexture; // Курсор при перетаскивании
        private Vector2 cursorHotspot; // Смещение курсора

        private InventorySlotUI placeholderSlot; // Временный слот-заглушка
        public static int tempIndex; //индекс перемещаемого слота в инвентаре
        public int slotIndex;
        private InventoryUI parentInventoryUI;
        public static IInventoryUI sourceInventoryUI;

        private RectTransformState originalRectState;
        private RectTransform rectTransform;
        
        public virtual ItemType? AcceptedType => null;


        private void Start()
        {
            if (parentInventoryUI == null)
            {
                parentInventoryUI = GetComponentInParent<InventoryUI>();

                if (parentInventoryUI == null)
                {
                    Debug.LogError($"❌ InventorySlotUI: не удалось найти родительский InventoryUI для {gameObject.name}");
                }
            }
        }
        // Устанавливаем слот в UI
        public virtual void SetSlot(InventorySlot newSlot)
        {
            slot = newSlot;

            if (slot != null && slot.item != null)
            {
                itemIcon.sprite = slot.item.icon;
                itemIcon.enabled = true;
                quantityText.text = slot.Quantity > 1 ? slot.Quantity.ToString() : "";
            }
            else
            {
                ClearSlot();
            }
        }

        // Очищаем UI слот
        public virtual void ClearSlot()
        {
            slot = null;
            itemIcon.sprite = null;
            itemIcon.enabled = false;
            quantityText.text = "";

            transform.SetSiblingIndex(transform.GetSiblingIndex()); // Гарантия, что UI-слот останется на месте
        }

        // Начало перетаскивания
        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            if (IsEquipmentSlot)
            {
                Debug.Log("ВНИМАНИЕ этот код для EquipmetnSlotUI ");
                if (Slot == null || Slot.item == null) return;

                draggedSlot = this;
                //originalParent = transform.parent;
                sourceInventoryUI = GetComponentInParent<IInventoryUI>();

                rectTransform = GetComponent<RectTransform>();

                originalRectState = new RectTransformState
                {
                    anchorMin = rectTransform.anchorMin,
                    anchorMax = rectTransform.anchorMax,
                    anchoredPosition = rectTransform.anchoredPosition,
                    sizeDelta = rectTransform.sizeDelta,
                    pivot = rectTransform.pivot,
                    rotation = rectTransform.localRotation,
                    scale = rectTransform.localScale
                };
                originalParent = transform.parent;
                sourceInventoryUI = GetComponentInParent<IInventoryUI>();

                // Получаем индекс текущего слота в родителе
                tempIndex = transform.GetSiblingIndex();

                // Создаем копию слота (заглушку)
                placeholderSlot = Instantiate(gameObject, originalParent).GetComponent<InventorySlotUI>();
                placeholderSlot.SetSlot(slot); // Копируем данные
                placeholderSlot.itemIcon.color = new Color(1, 1, 1, 0.5f); // Делаем полупрозрачной

                // Проверяем, есть ли CanvasGroup, если нет — добавляем
                CanvasGroup canvasGroup1 = placeholderSlot.GetComponent<CanvasGroup>();
                if (canvasGroup1 == null)
                {
                    canvasGroup1 = placeholderSlot.gameObject.AddComponent<CanvasGroup>();
                }
                canvasGroup1.blocksRaycasts = false; // Отключаем, чтобы заглушка не мешала

                // Вставляем заглушку на место оригинального слота
                placeholderSlot.transform.SetSiblingIndex(tempIndex);

                // Перемещаем оригинальный слот в корень UI
                transform.SetParent(transform.root);
                transform.SetAsLastSibling();
                itemIcon.raycastTarget = false; // Отключаем блокировку мыши

                // Меняем курсор на иконку предмета
                ChangeCursorToItemIcon(Slot.item.icon);
                return;
            }


            if (slot == null || slot.item == null) return;

            draggedSlot = this;
            originalParent = transform.parent;
            sourceInventoryUI = GetComponentInParent<IInventoryUI>();

            // Получаем индекс текущего слота в родителе
            tempIndex = transform.GetSiblingIndex();

            // Создаем копию слота (заглушку)
            placeholderSlot = Instantiate(gameObject, originalParent).GetComponent<InventorySlotUI>();
            placeholderSlot.SetSlot(slot); // Копируем данные
            placeholderSlot.itemIcon.color = new Color(1, 1, 1, 0.5f); // Делаем полупрозрачной

            // Проверяем, есть ли CanvasGroup, если нет — добавляем
            CanvasGroup canvasGroup = placeholderSlot.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = placeholderSlot.gameObject.AddComponent<CanvasGroup>();
            }
            canvasGroup.blocksRaycasts = false; // Отключаем, чтобы заглушка не мешала

            // Вставляем заглушку на место оригинального слота
            placeholderSlot.transform.SetSiblingIndex(tempIndex);

            // Перемещаем оригинальный слот в корень UI
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            itemIcon.raycastTarget = false; // Отключаем блокировку мыши

            // Меняем курсор на иконку предмета
            ChangeCursorToItemIcon(slot.item.icon);
        }

        // Перетаскивание
        public void OnDrag(PointerEventData eventData)
        {
            if (draggedSlot == null) return;
            transform.position = eventData.position;
        }

        // Завершение перетаскивания
        public virtual void OnEndDrag(PointerEventData eventData)
        {
            if (draggedSlot == null) return;

            if (IsEquipmentSlot)
            {
                if (draggedSlot == null) return;

                itemIcon.raycastTarget = true; // Включаем обратно блокировку мыши
                if (placeholderSlot != null)
                {
                    // 1. Перемещаем предмет на место заглушки
                    transform.SetParent(placeholderSlot.transform.parent);
                    transform.SetSiblingIndex(placeholderSlot.transform.GetSiblingIndex());

                    // 2. Теперь можно удалить заглушку
                    Destroy(placeholderSlot.gameObject);
                    placeholderSlot = null;
                } else
                {
                    transform.SetParent(originalParent, false);
                }
                    
                Debug.Log("ВНИМАНИЕ этот код для EQuipmetnSlotUI ");
                rectTransform.anchorMin = originalRectState.anchorMin;
                rectTransform.anchorMax = originalRectState.anchorMax;
                rectTransform.anchoredPosition = originalRectState.anchoredPosition;
                rectTransform.sizeDelta = originalRectState.sizeDelta;
                rectTransform.pivot = originalRectState.pivot;
                rectTransform.localRotation = originalRectState.rotation;
                rectTransform.localScale = originalRectState.scale;

                draggedSlot = null;

                // 3. Возвращаем стандартный курсор
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                return;
            }

            itemIcon.raycastTarget = true; // Включаем обратно блокировку мыши

            if (placeholderSlot != null)
            {
                // 1. Перемещаем предмет на место заглушки
                transform.SetParent(placeholderSlot.transform.parent);
                transform.SetSiblingIndex(placeholderSlot.transform.GetSiblingIndex());

                // 2. Теперь можно удалить заглушку
                Destroy(placeholderSlot.gameObject);
                placeholderSlot = null;
            }
            else
            {
                // Если placeholderSlot почему-то не существует, возвращаем предмет обратно
                transform.SetParent(originalParent);
                transform.localPosition = Vector3.zero;
            }

            draggedSlot = null;

            // 3. Возвращаем стандартный курсор
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        // Обработка дропа в другой слот
        public virtual void OnDrop(PointerEventData eventData)
        {
            if (draggedSlot == null || draggedSlot == this) return;

            Debug.Log($"Перемещение предмета {draggedSlot.slot.item.itemName} в новый слот");

            SwapItems(draggedSlot, sourceInventoryUI);
        }

        public virtual void SwapItems(InventorySlotUI otherSlot, IInventoryUI otherInventoryUI)
        {
            if (!ValidateSlots(otherSlot, otherInventoryUI))
                return;

            var thisInventoryUI = GetComponentInParent<IInventoryUI>();
            var thisInventory = thisInventoryUI.inventory;
            var otherInventory = otherInventoryUI.inventory;

            int thisIndex = transform.GetSiblingIndex();
            int otherIndex = tempIndex;

            // НОВОЕ: если текущий слот — экипировка, а другой — обычный инвентарь
            if (IsEquipmentSlot && !otherSlot.IsEquipmentSlot)
            {
                TransferFromInventoryToEquipment(thisInventory, otherInventory, thisIndex, otherIndex, otherSlot);
            }
            else if (IsEquipmentSlot && otherSlot.IsEquipmentSlot)
            {
                TransferFromEquipmentToEquipment(thisInventory, otherInventory, thisIndex, otherIndex, otherSlot);
            }
            else if (thisInventory == otherInventory)
            {
                SwapWithinSameInventory(thisInventory, thisIndex, otherIndex, otherSlot);
            }
            else
            {
                SwapBetweenDifferentInventories(thisInventory, otherInventory, thisIndex, otherIndex, otherSlot);
            }
        }

        // -----------------------------------------
        // Вспомогательные методы
        // -----------------------------------------

        private bool ValidateSlots(InventorySlotUI otherSlot, IInventoryUI otherInventoryUI)
        {
            if (otherSlot == null)
            {
                Debug.LogError("❌ Ошибка: otherSlot равен null!");
                return false;
            }

            if (otherInventoryUI == null)
            {
                Debug.LogError("❌ Ошибка: otherInventoryUI равен null!");
                return false;
            }

            var thisInventoryUI = GetComponentInParent<IInventoryUI>();
            if (thisInventoryUI == null || thisInventoryUI.inventory == null)
            {
                Debug.LogError("❌ Ошибка: Inventory или InventoryUI не найден!");
                return false;
            }

            return true;
        }

        private void SwapWithinSameInventory(Inventory inventory, int thisIndex, int otherIndex, InventorySlotUI otherSlot)
        {
            if (!AreIndicesValid(inventory, thisIndex, otherIndex)) return;

            Debug.Log($"🔄 Перемещаем предметы внутри одного инвентаря [{thisIndex}] ⇄ [{otherIndex}]");

            InventorySlot temp = inventory.slots[thisIndex];
            inventory.slots[thisIndex] = inventory.slots[otherIndex];
            inventory.slots[otherIndex] = temp;

            InventorySlot tempUI = otherSlot.slot;
            otherSlot.SetSlot(this.slot);
            this.SetSlot(tempUI);
        }

        private void SwapBetweenDifferentInventories(Inventory inventory, Inventory otherInventory, int thisIndex, int otherIndex, InventorySlotUI otherSlot)
        {
            if (otherSlot.IsEquipmentSlot)
            {
                TransferFromEquipmentToInventory(inventory, otherInventory, thisIndex, otherIndex, otherSlot);
            }
            else
            {
                TransferBetweenInventories(inventory, otherInventory, thisIndex, otherIndex, otherSlot);
            }
        }

        private void TransferFromEquipmentToEquipment(Inventory inventory, Inventory otherInventory, int thisIndex, int otherIndex, InventorySlotUI otherSlot)
        {
            Debug.Log("🎯 Переносим предмет из экипировки в Экипировку");
            var equipmentInventory = otherInventory as PersonalInventory;
            if (equipmentInventory == null)
            {
                Debug.LogError("❌ Ошибка: Inventory не является EquipmentInventory.");
                return;
            }
            var secondEquipmentInventory = inventory as PersonalInventory;
            if (secondEquipmentInventory == null)
            {
                Debug.LogError("❌ Ошибка: Second Inventory не является EquipmentInventory.");
                return;
            }
            if (AcceptedType.HasValue && equipmentInventory.equipmentSlots[otherIndex].slot.item.itemType != AcceptedType.Value)
            {
                Debug.LogWarning($"❌ Этот слот принимает {AcceptedType.Value}, а не {equipmentInventory.equipmentSlots[otherIndex].slot.item.itemType}");
                return;
            }

            if (secondEquipmentInventory.equipmentSlots[thisIndex].slot == null || secondEquipmentInventory.equipmentSlots[thisIndex].slot.item == null)
            {
                Debug.Log("🎯 Слот экипировки КУДА переносим - пустой. Просто удаляем из старой и экипируем");
                secondEquipmentInventory.Equip(thisIndex, equipmentInventory.equipmentSlots[otherIndex].slot.item);
                equipmentInventory.UnEquip(otherIndex);
            } else
            {
                Debug.Log("🎯 Меняем экипировку местами");
                InventorySlot tempEquipment = secondEquipmentInventory.equipmentSlots[thisIndex].slot;
                secondEquipmentInventory.UnEquip(thisIndex);
                secondEquipmentInventory.Equip(thisIndex, equipmentInventory.equipmentSlots[otherIndex].slot.item);
                equipmentInventory.UnEquip(otherIndex);
                equipmentInventory.Equip(otherIndex, tempEquipment.item);
            }

        }

        private void TransferFromEquipmentToInventory(Inventory inventory, Inventory otherInventory, int thisIndex, int otherIndex, InventorySlotUI otherSlot)
        {
            Debug.Log("🎯 Переносим предмет из экипировки в инвентарь");
            var equipmentInventory = otherInventory as PersonalInventory;
            if (equipmentInventory == null)
            {
                Debug.LogError("❌ Ошибка: Inventory не является EquipmentInventory.");
                return;
            }

            if (inventory.slots[thisIndex] == null || inventory.slots[thisIndex].item == null)
            {
                if (inventory.CountEmptySlots() >=
                    equipmentInventory.equipmentSlots[otherIndex].slot.item.inventorySlotsCount)
                {
                    // Слот пустой, просто забираем предмет
                    inventory.AddItemToSlot(thisIndex, equipmentInventory.equipmentSlots[otherIndex].slot.item, equipmentInventory.equipmentSlots[otherIndex].slot.Quantity);
                    equipmentInventory.UnEquip(otherIndex);
                }
                else
                {
                    Debug.LogWarning("❌ НУЖНО ОСВОБОДИТЬ СЛОТЫ ДЛЯ СНЯТИЯ ЭКИПИРОВКИ.");
                }
            }
            else
            {
                // Слот занят, пытаемся переэкипировать
                if (equipmentInventory.TryEquip(inventory.slots[thisIndex].item))
                {
                    InventorySlot temp = inventory.slots[thisIndex];
                    InventorySlot previousEquipment = equipmentInventory.equipmentSlots[otherIndex].slot;

                    inventory.RemoveItemFromSlot(thisIndex, temp.Quantity);
                    inventory.AddItemToSlot(thisIndex, previousEquipment.item, previousEquipment.Quantity);

                    equipmentInventory.UnEquip(otherIndex);
                    equipmentInventory.Equip(otherIndex, temp.item);
                    
                    otherSlot.SetSlot(temp);
                    this.SetSlot(new InventorySlot(previousEquipment.item, previousEquipment.Quantity));
                    Debug.Log($"В ИНВЕНТАРЕ ТЕПЕРЬ {inventory.slots[thisIndex].item}, а в ЭКИПИРОВКЕ {equipmentInventory.equipmentSlots[otherIndex].slot.item}");
                }
                else if (inventory.TryAddItem(equipmentInventory.equipmentSlots[otherIndex].slot.item, equipmentInventory.equipmentSlots[otherIndex].slot.Quantity))
                {
                    // Если не удалось экипировать, но есть место в инвентаре
                    inventory.AddItem(equipmentInventory.equipmentSlots[otherIndex].slot.item, equipmentInventory.equipmentSlots[otherIndex].slot.Quantity);
                    equipmentInventory.UnEquip(otherIndex);
                }
                else
                {
                    Debug.LogWarning("❌ Нет места в инвентаре для снятия экипировки.");
                }
            }
        }

        private void TransferBetweenInventories(Inventory inventory, Inventory otherInventory, int thisIndex, int otherIndex, InventorySlotUI otherSlot)
        {
            Debug.Log("📦 Перенос предмета между разными инвентарями");

            if (inventory.slots[thisIndex] == null || inventory.slots[thisIndex].item == null)
            {
                inventory.AddItemToSlot(thisIndex, otherInventory.slots[otherIndex].item, otherInventory.slots[otherIndex].Quantity);
                otherInventory.RemoveItemFromSlot(otherIndex, otherInventory.slots[otherIndex].Quantity);
                otherSlot.ClearSlot();
            }
            else
            {
                InventorySlot temp = inventory.slots[thisIndex];
                InventorySlot tempUI = this.slot;

                inventory.RemoveItemFromSlot(thisIndex, temp.Quantity);
                inventory.AddItemToSlot(thisIndex, otherInventory.slots[otherIndex].item, otherInventory.slots[otherIndex].Quantity);

                otherInventory.RemoveItemFromSlot(otherIndex, otherInventory.slots[otherIndex].Quantity);
                otherInventory.AddItemToSlot(otherIndex, temp.item, temp.Quantity);

                otherSlot.SetSlot(tempUI);
                this.SetSlot(this.slot);
            }
        }

        private void TransferFromInventoryToEquipment(Inventory thisInventory, Inventory otherInventory, int thisIndex, int otherIndex, InventorySlotUI otherSlot)
        {
            Debug.Log("⚔️ Перенос предмета из инвентаря в экипировку ???????????????? В ЭКИПИРОВКУ");

            var itemToEquip = otherInventory.slots[otherIndex]?.item;
            if (itemToEquip == null)
            {
                Debug.LogWarning("❌ Нет предмета для экипировки.");
                return;
            }

            var equipmentInventory = thisInventory as PersonalInventory;
            if (equipmentInventory == null)
            {
                Debug.LogError("❌ Ошибка: Inventory не является EquipmentInventory.");
                return;
            }

            if (AcceptedType.HasValue && itemToEquip.itemType != AcceptedType.Value)
            {
                Debug.LogWarning($"❌ Этот слот принимает {AcceptedType.Value}, а не {itemToEquip.itemType}");
                return;
            }

            // Пытаемся экипировать
            if (equipmentInventory.TryEquip(itemToEquip))
            {
                Debug.Log($"✅ Предмет {itemToEquip.itemName} экипирован в слот {AcceptedType.Value}");

                // Если в экипировке уже что-то было
                //thisIndex = transform.GetSiblingIndex();
                Debug.Log($"thisIndex {thisIndex}");
                if (equipmentInventory.equipmentSlots[thisIndex].slot != null &&
                    equipmentInventory.equipmentSlots[thisIndex].slot.item != null)
                {
                    InventorySlot previousEquipment = equipmentInventory.equipmentSlots[thisIndex].slot;
                    InventorySlot tempUI = this.slot;

                    Debug.Log($"🔄 Возвращаем {previousEquipment.item.itemName} обратно в инвентарь");

                    // Убираем старую экипировку и возвращаем в инвентарь
                    otherInventory.RemoveItemFromSlot(otherIndex, otherInventory.slots[otherIndex].Quantity);
                    otherInventory.AddItemToSlot(otherIndex, previousEquipment.item, previousEquipment.Quantity);
                    //экипируем новым предметом
                    equipmentInventory.UnEquip(thisIndex);
                    equipmentInventory.Equip(thisIndex, itemToEquip);
                    // Обновляем UI
                    //SetSlot(new InventorySlot(itemToEquip, 1)); - ДЛЯ ЭКИПИРОВКИ ТАКОЕ КАЖЕТСЯ НЕ НУЖНО, можно будет поудалять
                    otherSlot.SetSlot(tempUI);
                    Debug.Log($"В ИНВЕНТАРЕ ТЕПЕРЬ {otherInventory.slots[otherIndex].item}, а в ЭКИПИРОВКЕ {equipmentInventory.equipmentSlots[thisIndex].slot.item}");
                }
                else
                {
                    Debug.Log("🆕 Экипировка была пустая, просто экипируем новый предмет");

                    // Просто удаляем предмет из инвентаря
                    otherInventory.RemoveItemFromSlot(otherIndex, otherInventory.slots[otherIndex].Quantity);

                    // Обновляем UI
                    equipmentInventory.Equip(thisIndex, itemToEquip);
                    SetSlot(new InventorySlot(itemToEquip, 1));
                    otherSlot.ClearSlot();
                }
            }
            else
            {
                Debug.LogWarning("❌ Не удалось экипировать предмет.");
            }
        }

        private bool AreIndicesValid(Inventory inventory, int index1, int index2)
        {
            if (index1 < 0 || index1 >= inventory.slots.Count || index2 < 0 || index2 >= inventory.slots.Count)
            {
                Debug.LogError($"❌ Ошибка: Некорректные индексы! index1 = {index1}, index2 = {index2}");
                return false;
            }
            return true;
        }

        // Создаем курсор из иконки предмета
        public void ChangeCursorToItemIcon(Sprite itemSprite)
        {
            if (itemSprite == null) return;

            // Создаем текстуру для курсора
            dragCursorTexture = new Texture2D((int)itemSprite.rect.width, (int)itemSprite.rect.height, TextureFormat.RGBA32, false);
            Color[] pixels = itemSprite.texture.GetPixels(
                (int)itemSprite.rect.x,
                (int)itemSprite.rect.y,
                (int)itemSprite.rect.width,
                (int)itemSprite.rect.height
            );
            dragCursorTexture.SetPixels(pixels);
            dragCursorTexture.Apply();

            // Устанавливаем точку захвата в центр иконки
            cursorHotspot = new Vector2(dragCursorTexture.width / 2, dragCursorTexture.height / 2);

            // Устанавливаем курсор
            Cursor.SetCursor(dragCursorTexture, cursorHotspot, CursorMode.Auto);
        }
    }
}

