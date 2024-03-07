using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;
using System;
public class ItemSlot : MonoBehaviour
{


    //ITEM DATA//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;

    //ITEM SLOT//
    [SerializeField]
    private TextMeshProUGUI quantitytext;

    [SerializeField]
    private Image itemImage;


    //ITEM DESCRIPTION SLOT//
    public Image itemDescriptionImage;
    public TextMeshProUGUI ItemDescriptionNameText;
    public TextMeshProUGUI ItemDescriptionText;


    [SerializeField]
    public GameObject selectedShader;
    public bool isSelected;





    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }
    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
        isFull = true;

        quantitytext.text = quantity.ToString();
        quantitytext.enabled = true;
        itemImage.sprite = itemSprite;
    }
    // Method to remove the item from the slot
    public void RemoveItem()
    {
        itemName = "";
        quantity = 0;
        itemDescription = "";
        isFull = false;

        ItemDescriptionText.text = itemDescription;
        ItemDescriptionNameText.text = itemName;


        quantitytext.text = "";
        quantitytext.enabled = false;
        itemImage.sprite = emptySprite;
        itemDescriptionImage.sprite = emptySprite;
    }














}
