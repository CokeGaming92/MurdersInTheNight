using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public float grabDistance = 5f;
    public LayerMask interactableLayer;
    private GameObject grabbedObject;
   [SerializeField] private bool isGrabbing = false;

    [SerializeField] private Transform gameObjectTransform;

    // Assuming yOffset is a variable that represents the offset between the player and the grabbed object
    float yOffset = 2.0f; // Adjust this value based on your needs
    public bool isLocked;
     void Start()
    {
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
      
    }
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            if (!isGrabbing)
                TryGrabObject();
            else
                DropObject();
        }

        if (isGrabbing)
            LiftObject();
    }

    void TryGrabObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, grabDistance, interactableLayer))
        {
            if (hit.collider.CompareTag("InteractObject"))
            {
                grabbedObject = hit.collider.gameObject;
                isGrabbing = true;

                // Disable physics simulation while grabbing
                grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    void LiftObject()
    {

        // Assuming yOffset is a variable that represents the offset between the player and the grabbed object
        float yOffset = 2.0f; // Adjust this value based on your needs

        // Get the camera's forward direction (look direction)
        Vector3 cameraForward = Camera.main.transform.forward;

        // Update the grabbed object's position based on the player's look direction
        grabbedObject.transform.position = gameObjectTransform.position + yOffset * cameraForward;

        // You may need to adjust the above logic based on your specific requirements.
        // For example, you might want to add the player's forward or right direction to the object's position.
    }

    void DropObject()
    {
        isGrabbing = false;

        // Enable physics simulation after dropping
        grabbedObject.GetComponent<Rigidbody>().isKinematic = false;

        grabbedObject = null;
    }

}