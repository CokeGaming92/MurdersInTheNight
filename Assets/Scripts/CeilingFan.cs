using UnityEngine;

public class CeilingFan : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Check for input or any other condition to trigger rotation
        // For example, you can use Input.GetKeyDown(KeyCode.Space) to rotate on spacebar press

        // Rotate the fan
        RotateFan();
    }

    void RotateFan()
    {
        // Rotate the fan around the Z-axis based on the rotationSpeed
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
