using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private int quantity;
    [SerializeField]
    private Sprite sprite;

    [TextArea]
    [SerializeField]
    private string itemDescription;

    [SerializeField] 
    private InventoryManager inventoryManager;

    private void Start()
    {
         inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }

     private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            Destroy(gameObject);
        }
    }
}
