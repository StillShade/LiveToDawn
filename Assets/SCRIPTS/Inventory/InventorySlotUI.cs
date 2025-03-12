using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class InventorySlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Image itemIcon;  // Иконка предмета
    public TMP_Text quantityText; // Количество предметов

    private InventorySlot slot; // Ссылка на слот инвентаря
    private Transform originalParent; // Для возврата иконки
    private static InventorySlotUI draggedSlot; // Какой слот перетаскиваем

    private Texture2D dragCursorTexture; // Курсор при перетаскивании
    private Vector2 cursorHotspot; // Смещение курсора

    // Устанавливаем слот в UI
    public void SetSlot(InventorySlot newSlot)
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
    public void ClearSlot()
    {
        slot = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false;
        quantityText.text = "";
    }

    // Начало перетаскивания
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (slot == null || slot.item == null) return;

        draggedSlot = this;
        originalParent = transform.parent;
        transform.SetParent(transform.root); // Перемещаем иконку в корень UI
        transform.SetAsLastSibling();
        itemIcon.raycastTarget = false; // Отключаем блокировку мыши

        // Меняем курсор на иконку предмета
        ChangeCursorToItemIcon(slot.item.icon);

        Debug.Log($"Начали перетаскивать {slot.item.itemName}");
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
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;

        draggedSlot = null;

        // Возвращаем стандартный курсор
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    // Обработка дропа в другой слот
    public void OnDrop(PointerEventData eventData)
    {
        if (draggedSlot == null || draggedSlot == this) return;

        Debug.Log($"Перемещение предмета {draggedSlot.slot.item.itemName} в новый слот");

        SwapItems(draggedSlot);
    }

    // Обмен предметами между слотами
    private void SwapItems(InventorySlotUI otherSlot)
    {
        InventorySlot temp = otherSlot.slot;
        otherSlot.SetSlot(this.slot);
        this.SetSlot(temp);

        Debug.Log("Предметы поменялись местами!");
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