using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private int quantity;
    [SerializeField]
    private Sprite sprite;

    private Transform playerTransform;
    [TextArea]
    [SerializeField]
    private string itemDescription;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] 
    private InventoryManager inventoryManager;

    [SerializeField] private float maxDistance = 2f; // Maximum distance for showing the description


    // Assuming you have a reference to the camera that will be used for raycasting
    public Camera raycastCamera;
    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // Disable the description text by default
        descriptionText.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Check if the player is within the maximum distance
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance >= maxDistance)
        {
            // Hide the description text when the mouse leaves the item
            descriptionText.gameObject.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
       
            // Show the description text when the player is within the maximum distance
            descriptionText.text = itemDescription;
            descriptionText.gameObject.SetActive(true);
        
    }
    private void OnMouseExit()
    {
        
            // Show the description text when the player is within the maximum distance
            descriptionText.text = itemDescription;
            descriptionText.gameObject.SetActive(false);
        
    }




}
