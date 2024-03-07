using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform lookAt;
    public Transform player;
    public float distance = 2f;
    public float sensitivity = 4.0f;
    public float rotationSpeed = 2.0f;

    [SerializeField] private float minYAngle = -20.0f;
    [SerializeField] private float maxYAngle = 60.0f;

    private float currentTheta = 0.0f;
    private float currentPhi = 30.0f;


   
    // Update is called once per frame
    void LateUpdate()
    {
        
        // Get mouse input
        currentTheta -= Input.GetAxis("Mouse X") * sensitivity;
        currentPhi += Input.GetAxis("Mouse Y") * sensitivity;
        currentPhi = Mathf.Clamp(currentPhi, minYAngle, maxYAngle);

        // Convert spherical coordinates to Cartesian coordinates
        float x = distance * Mathf.Sin(Mathf.Deg2Rad * currentPhi) * Mathf.Cos(Mathf.Deg2Rad * currentTheta);
        float y = distance * Mathf.Cos(Mathf.Deg2Rad * currentPhi);
        float z = distance * Mathf.Sin(Mathf.Deg2Rad * currentPhi) * Mathf.Sin(Mathf.Deg2Rad * currentTheta);

        // Update camera position and look at the player
        transform.position = new Vector3(x, y, z) + lookAt.position;
        transform.LookAt(lookAt.position);
        distance = 1f;

      

        // Rotate the player based on input
        player.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotationSpeed);


    }
}