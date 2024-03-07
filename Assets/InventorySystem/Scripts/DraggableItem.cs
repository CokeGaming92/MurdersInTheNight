using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
   [SerializeField] private ItemSlot itemSlot;
    public GameObject button;
    private bool buttonHide = false;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;
        itemSlot = GetComponentInParent<ItemSlot>();
    }

    public void Update()
    {
        if(itemSlot.quantity <= 0 )
        {
            button.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (itemSlot.isFull && itemSlot.quantity > 0)
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (itemSlot.isFull && itemSlot.quantity > 0)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (itemSlot.isFull && itemSlot.quantity > 0)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            rectTransform.anchoredPosition = originalPosition; // Snap back to original position
            ReadItem();
           buttonHide =! buttonHide;

            if (buttonHide)
            {
                button.SetActive(true);
            }
            if (!buttonHide)
            {
                button.SetActive(false);
            }
        }
        if(itemSlot.quantity <= 0)
        {
            button.SetActive(false);
        }
    }


    public void TrashItem()
    {
        if (itemSlot != null && itemSlot.isFull)
        {
            itemSlot.RemoveItem();
            Debug.Log("Item trashed!");
        }
    }
    private void ReadItem()
    {
        if (itemSlot != null)
        {
            Debug.Log("Item Name: " + itemSlot.itemName);
            Debug.Log("Description: " + itemSlot.itemDescription);

            itemSlot.itemDescriptionImage.sprite = itemSlot.itemSprite;
            itemSlot.ItemDescriptionText.text = itemSlot.itemDescription;
            itemSlot.ItemDescriptionNameText.text = itemSlot.itemName;
        }
    }
}