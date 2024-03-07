using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{


    public GameObject InventoryMenu;
    bool isHide = true;
    public ShowCursor showCursor;


    public ItemSO[] itemSOs;

    public ItemSlot[] itemSlots;
    public void Start()
    {
       
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            isHide = !isHide;

            if(isHide)
            {
                Time.timeScale = 1;
                showCursor.HideCursor();
                InventoryMenu.SetActive(false);
            }
            if(!isHide)
            {
                Time.timeScale = 0;
                showCursor.ShowCursorEnabled();
                InventoryMenu.SetActive(true);
            }
        }
    }

    

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].isFull == false) 
            {
                itemSlots[i].AddItem(itemName,quantity,itemSprite, itemDescription);
                return;
            }
        }
    }




    public void DeselectAllSlots()
    {
      for (int i = 0;i < itemSlots.Length;i++) 
        {
            itemSlots[i].selectedShader.SetActive(false);
            itemSlots[i].isSelected = false;
        }
    }
}