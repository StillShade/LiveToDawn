using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class InventorySlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Image itemIcon;  // ������ ��������
    public TMP_Text quantityText; // ���������� ���������

    private InventorySlot slot; // ������ �� ���� ���������
    private Transform originalParent; // ��� �������� ������
    private static InventorySlotUI draggedSlot; // ����� ���� �������������

    private Texture2D dragCursorTexture; // ������ ��� ��������������
    private Vector2 cursorHotspot; // �������� �������

    // ������������� ���� � UI
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

    // ������� UI ����
    public void ClearSlot()
    {
        slot = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false;
        quantityText.text = "";
    }

    // ������ ��������������
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (slot == null || slot.item == null) return;

        draggedSlot = this;
        originalParent = transform.parent;
        transform.SetParent(transform.root); // ���������� ������ � ������ UI
        transform.SetAsLastSibling();
        itemIcon.raycastTarget = false; // ��������� ���������� ����

        // ������ ������ �� ������ ��������
        ChangeCursorToItemIcon(slot.item.icon);

        Debug.Log($"������ ������������� {slot.item.itemName}");
    }

    // ��������������
    public void OnDrag(PointerEventData eventData)
    {
        if (draggedSlot == null) return;
        transform.position = eventData.position;
    }

    // ���������� ��������������
    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedSlot == null) return;

        itemIcon.raycastTarget = true; // �������� ������� ���������� ����
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;

        draggedSlot = null;

        // ���������� ����������� ������
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    // ��������� ����� � ������ ����
    public void OnDrop(PointerEventData eventData)
    {
        if (draggedSlot == null || draggedSlot == this) return;

        Debug.Log($"����������� �������� {draggedSlot.slot.item.itemName} � ����� ����");

        SwapItems(draggedSlot);
    }

    // ����� ���������� ����� �������
    private void SwapItems(InventorySlotUI otherSlot)
    {
        InventorySlot temp = otherSlot.slot;
        otherSlot.SetSlot(this.slot);
        this.SetSlot(temp);

        Debug.Log("�������� ���������� �������!");
    }

    // ������� ������ �� ������ ��������
    private void ChangeCursorToItemIcon(Sprite itemSprite)
    {
        if (itemSprite == null) return;

        // ������� �������� ��� �������
        dragCursorTexture = new Texture2D((int)itemSprite.rect.width, (int)itemSprite.rect.height, TextureFormat.RGBA32, false);
        Color[] pixels = itemSprite.texture.GetPixels(
            (int)itemSprite.rect.x,
            (int)itemSprite.rect.y,
            (int)itemSprite.rect.width,
            (int)itemSprite.rect.height
        );
        dragCursorTexture.SetPixels(pixels);
        dragCursorTexture.Apply();

        // ������������� ����� ������� � ����� ������
        cursorHotspot = new Vector2(dragCursorTexture.width / 2, dragCursorTexture.height / 2);

        // ������������� ������
        Cursor.SetCursor(dragCursorTexture, cursorHotspot, CursorMode.Auto);
    }
}