// HeadLookAt.cs
using UnityEngine;

public class HeadLookAt : MonoBehaviour
{
    public float rotationSpeed = 5f; // Speed at which the head rotates
    public float xRotationClamp = 45f; // Maximum allowed rotation on the X-axis
    private Transform headTransform; // Reference to the head's transform
    private Quaternion originalRotation;

    void Start()
    {
        // Save the original rotation of the head
        originalRotation = transform.localRotation;

        // Assuming this is the head
        headTransform = this.gameObject.transform;
    }

    void Update()
    {
        RotateHeadWithMouseInput();
    }

    void RotateHeadWithMouseInput()
    {
        // Get the horizontal mouse movement
        float mouseX = Input.GetAxis("Mouse X");

        // Calculate the new rotation based on mouse movement
        Quaternion newRotation = originalRotation * Quaternion.Euler(0f, mouseX * rotationSpeed, 0f);

        // Clamp the rotation on the X-axis within the specified range
        newRotation = ClampXRotation(newRotation);

        // Apply the new rotation to the head
        headTransform.rotation = newRotation;
    }

    Quaternion ClampXRotation(Quaternion rotation)
    {
        // Convert the rotation to euler angles for easier manipulation
        Vector3 eulerAngles = rotation.eulerAngles;

        // Clamp the rotation on the X-axis within the specified range
        eulerAngles.x = Mathf.Clamp(eulerAngles.x, -xRotationClamp, xRotationClamp);

        // Convert back to quaternion
        return Quaternion.Euler(eulerAngles);
    }

    public void ResetHeadRotation()
    {
        // If needed, reset the head rotation
        headTransform.localRotation = originalRotation;
    }
}