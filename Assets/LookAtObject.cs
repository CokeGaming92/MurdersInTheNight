using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    public Transform target;
    public float maxDistance = 5f;
    public Transform headTransform;
    public float maxRotationAngle = 45f;

    public Quaternion initialRotation;

     void Start()
    {
        // Store the initial rotation at the start
        initialRotation = headTransform.rotation;
    }
    void Update()
    {
        if (target != null)
        {
            // Calculate the direction to the target
            Vector3 directionToTarget = target.position - transform.position;

            // Check if the target is within maxDistance
            if (directionToTarget.magnitude <= maxDistance)
            {
                // Calculate the rotation to look at the target
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

                // Apply rotation with angle constraints
                float angle = Quaternion.Angle(headTransform.rotation, targetRotation);
                if (angle <= maxRotationAngle)
                {
                    headTransform.rotation = Quaternion.RotateTowards(headTransform.rotation, targetRotation, maxRotationAngle);
                }
            }

            else
            {
                // Calculate the rotation towards the player's transform
                Quaternion playerDirectionRotation = Quaternion.LookRotation(transform.forward);

                // Apply rotation with angle constraints
                float playerAngle = Quaternion.Angle(headTransform.rotation, playerDirectionRotation);
                if (playerAngle <= maxRotationAngle)
                {
                    headTransform.rotation = Quaternion.RotateTowards(headTransform.rotation, playerDirectionRotation, maxRotationAngle);
                }
            }
        }
    }

}