using System.Collections;
using UnityEngine;


public class ShootingController : MonoBehaviour
{
    public Transform gunTip; // The position where bullets will be spawned
    public GameObject bulletPrefab; // Prefab of your bullet
    public float bulletSpeed = 10f; // Speed of the bullet
    public float bulletLifetime = 2f; // Duration the bullet will stay active
    public float timeBetweenShots = 0.5f; // Time between consecutive shots
   
    private bool isShooting;
   [SerializeField] private Animator animator;

    private void Start()
    {
        
    }

    private void Update()
    {
        ShootingMechanic();
    }

    private void ShootingMechanic()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Mouse button is pressed down, start shooting
            isShooting = true;

            // Trigger the shooting animation
            animator.SetBool("isShooting", true);

            // Start shooting bullets
            StartCoroutine(ShootBullets());
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Mouse button is released, stop shooting
            isShooting = false;

            // Reset the shooting animation
            animator.SetBool("isShooting", false);
        }
    }

    private IEnumerator ShootBullets()
    {
        while (isShooting)
        {
            // Instantiate a bullet at the gun tip position
            GameObject bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);

            // Set the bullet's initial speed
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = gunTip.forward * bulletSpeed;
            }

            // Set the bullet as active
            bullet.SetActive(true);

            // Deactivate the bullet after a certain lifetime
            StartCoroutine(DeactivateBulletAfterLifetime(bullet));

            // Wait for the specified time between shots
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
    private IEnumerator DeactivateBulletAfterLifetime(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletLifetime);

        // Deactivate the bullet after the specified lifetime
        Destroy(bullet);
    }
}