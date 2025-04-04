using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



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

    private Texture2D dragCursorTexture; // Курсор при перетаскивании
    private Vector2 cursorHotspot; // Смещение курсора

    private InventorySlotUI placeholderSlot; // Временный слот-заглушка
    public static int tempIndex; //индекс перемещаемого слота в инвентаре
    public int slotIndex;
    private InventoryUI parentInventoryUI;
    public static IInventoryUI sourceInventoryUI;


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
    public void OnBeginDrag(PointerEventData eventData)
    {
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
    public void OnEndDrag(PointerEventData eventData)
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

    // Обмен предметами между слотами
    private void SwapItems(InventorySlotUI otherSlot, IInventoryUI otherInventoryUI )
    {
        if (otherSlot == null)
        {
            Debug.LogError("Ошибка: otherSlot равен null!");
            return;
        }

        if (otherInventoryUI == null)
        {
            Debug.LogError("Ошибка: otherInventoryUI равен null (не определен)!");
            return;
        }

        var thisInventoryUI = GetComponentInParent<IInventoryUI>();
        if (thisInventoryUI == null)
        {
            Debug.LogError("❌ InventoryUI не найден у текущего слота!");
            return;
        }
        Inventory inventory = thisInventoryUI.inventory;

        if (inventory == null)
        {
            Debug.LogError("Ошибка: Inventory не найден у InventoryUI!");
            return;
        }
        Inventory otherInventory = otherInventoryUI.inventory;
        Debug.Log($"inventory == otherInventory  {inventory == otherInventory}");

        if (inventory == otherInventory)
        {
            // Получаем индексы из UI
            int thisIndex = transform.GetSiblingIndex();
            int otherIndex = tempIndex;
            Debug.Log($"thisIndex = {thisIndex}, otherIndex = {otherIndex}");

            // Проверяем, что индексы корректны
            if (thisIndex < 0 || thisIndex >= inventory.slots.Count ||
                otherIndex < 0 || otherIndex >= inventory.slots.Count)
            {
                Debug.LogError($"Ошибка: Некорректные индексы! thisIndex = {thisIndex}, otherIndex = {otherIndex}");
                return;
            }

            // Если перетаскиваем предмет в пустой слот
            if (inventory.slots[thisIndex] == null)
            {
                inventory.slots[thisIndex] = inventory.slots[otherIndex]; // Переносим предмет
                inventory.slots[otherIndex] = null; // Очищаем текущий слот
            }
            else // Обычный обмен предметами
            {
                InventorySlot temp = inventory.slots[thisIndex];
                inventory.slots[thisIndex] = inventory.slots[otherIndex];
                inventory.slots[otherIndex] = temp;
            }

            InventorySlot tempUI = otherSlot.slot;
            otherSlot.SetSlot(this.slot);
            this.SetSlot(tempUI);

            // Обновляем UI ранее было inventory.inventoryUI.UpdateUI();
            // возможно вообще не нужно inventory.OnInventoryChanged?.Invoke();

            Debug.Log($"Предметы поменялись местами! [{thisIndex}] ⇄ [{otherIndex}]");
        } else
        {
            // Получаем индексы из UI
            int thisIndex = transform.GetSiblingIndex();
            int otherIndex = tempIndex;
            
            // Проверяем, что индексы корректны
            if (thisIndex < 0 || thisIndex >= inventory.slots.Count)
            {
                Debug.LogError($"Ошибка: Некорректные индексы! thisIndex = {thisIndex}, otherIndex = {otherIndex}");
                return;
            }
            Debug.Log($"item {otherInventory.slots[otherIndex].item}");

            if (inventory.slots[thisIndex] == null || inventory.slots[thisIndex].item == null)
            {
                inventory.AddItemToSlot(thisIndex, otherInventory.slots[otherIndex].item, otherInventory.slots[otherIndex].Quantity);
                otherInventory.RemoveItemFromSlot(otherIndex, otherInventory.slots[otherIndex].Quantity);
                otherSlot.ClearSlot();
            } else
            {
                Debug.Log($"слот не пустой");
                InventorySlot temp = inventory.slots[thisIndex];
                InventorySlot tempUI = this.slot;
                inventory.RemoveItemFromSlot(thisIndex, inventory.slots[thisIndex].Quantity);
                inventory.AddItemToSlot(thisIndex, otherInventory.slots[otherIndex].item, otherInventory.slots[otherIndex].Quantity);
                otherInventory.RemoveItemFromSlot(otherIndex, otherInventory.slots[otherIndex].Quantity);
                otherInventory.AddItemToSlot(otherIndex, temp.item, temp.Quantity);
                otherSlot.SetSlot(tempUI);
                this.SetSlot(this.slot);
            }
        }
        
    }

    // Создаем курсор из иконки предмета
    private void ChangeCursorToItemIcon(Sprite itemSprite)
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