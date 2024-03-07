using UnityEngine;

public class HingeDoorController : MonoBehaviour
{

    public HingeJoint doorHingeJoint;
    public float interactForce = 500f;

    void Update()
    {
        // Example: Press 'E' to interact with the door
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithDoor();
        }
    }

    void InteractWithDoor()
    {
        if (doorHingeJoint != null)
        {
            // Enable the motor to apply force
            JointMotor motor = doorHingeJoint.motor;
            motor.force = interactForce;
            doorHingeJoint.motor = motor;

            // Enable the spring to provide smooth movement
            JointSpring spring = doorHingeJoint.spring;
            spring.spring = 0.1f; // Adjust as needed
            spring.targetPosition = 90f; // Adjust as needed
            doorHingeJoint.spring = spring;

            // Apply the force and start moving the door
            doorHingeJoint.useMotor = true;
        }
    }
}
