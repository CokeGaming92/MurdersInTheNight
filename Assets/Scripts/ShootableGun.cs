using UnityEngine;

public class ShootableGun : MonoBehaviour
{
    public Transform gunBarrel;        // Reference to the gun barrel's transform
    public GameObject bulletPrefab;    // Prefab of the bullet to be shot
    public float bulletSpeed = 10f;    // Speed of the bullet
    public AudioClip shootSound;       // Sound played when shooting
    public float bulletLifeTime = 3f;  // Time before the bullet is destroyed
    void Update()
    {
        // Check for input to shoot
        if (Input.GetButtonDown("Fire1"))  // Assumes "Fire1" is set up in Unity Input Manager
        {
            Shoot();
        }


    }

    void Shoot()
    {
        // Instantiate a bullet at the gun barrel's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);

        // Access the Rigidbody component of the bullet and apply force forward
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.velocity = gunBarrel.forward * bulletSpeed;
        }
      
        

        // Play shooting sound
        if (shootSound != null)
        {
            AudioSource.PlayClipAtPoint(shootSound, gunBarrel.position);
        }

        // Destroy the instantiated bullet prefab after a certain period of time
        Destroy(bullet, bulletLifeTime);
    }


}