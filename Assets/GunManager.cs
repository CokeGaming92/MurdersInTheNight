
using System.Buffers.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GunManager : MonoBehaviour
{
    public SimpleThirdPersonController personController;

    public GameObject muzzleFlash;
    public GameObject gun, gun_UI;
    public Transform gunTransform;  // Assign the gun's transform in the Unity Editor
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    [SerializeField] private Animator animator;

    public TextMeshProUGUI bulletCountText;
    public int maxBulletCount = 10;
    private int currentBulletCount;

    //Holster Weapon
    [SerializeField] private bool gunOut;
    public AudioSource audioHolster;
    public AudioClip[] audioHolsterClips;

    private bool isShooting = false;

    private bool isReloadable = false;

    public GameObject audio_Shoot;
    public CameraMove thirdPersonCamera;
  
    private void Start()
    {
        // Initialize bullet count
        currentBulletCount = maxBulletCount;
        UpdateBulletCountUI();
    }
    private void Update()
    {
        HandleShootingInput();
        Gun();
    }
    public void GunPickup()
    {
        gunOut = true;
    }

    public void Reload()
    {
      isReloadable = true;
    }
    private void Gun()
    {

      if(isReloadable == true)
        {
            if (currentBulletCount <= 0)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    currentBulletCount = 10;
                    bulletCountText.text = " " + currentBulletCount;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            gunOut = !gunOut;
            if (gunOut)
            {
                audioHolster.clip = audioHolsterClips[0];
                audioHolster.Play();
            }
            if (!gunOut)
            {
                gun.SetActive(false);
                gun_UI.SetActive(false);
              
                audioHolster.clip = audioHolsterClips[1];
                audioHolster.Play();
            }
        }
        if (gunOut)
        {
            gun.SetActive(true);
            gun_UI.SetActive(true);
           

        }
        if (!gunOut)
        {
            
            animator.Play("Blend Tree");
            audio_Shoot.SetActive(false);
            muzzleFlash.SetActive(false);

        }

    }

    private void HandleShootingInput()
    {
        if (gunOut)
        {
            if (Input.GetKeyUp(KeyCode.Mouse1))  // Change "Fire1" to the appropriate input axis/button
            {
                isShooting = false;
                audio_Shoot.SetActive(false);
                animator.Play("Blend Tree");
              
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                isShooting = true;
                animator.Play("gunup");
             

            }
            if (isShooting)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))  // Change "Fire1" to the appropriate input axis/button
                {
                    isShooting = true;




                    if (currentBulletCount > 0)
                    {

                        Shoot();

                        muzzleFlash.SetActive(true);
                        audio_Shoot.SetActive(true);
                        muzzleFlash.GetComponent<ParticleSystem>().Play();
                        currentBulletCount--;
                        UpdateBulletCountUI();
                    }




                }
            }
            if (!isShooting)
            {
                muzzleFlash.SetActive(false);
            }
        }

    }
    private void UpdateBulletCountUI()
    {
        if (bulletCountText != null)
        {
            bulletCountText.text = "" + currentBulletCount;
        }
    }

    private void Shoot()
    {
        if (gunTransform != null && bulletPrefab != null && bulletSpawnPoint != null)
        {
            // Instantiate a bullet at the bullet spawn point
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            // Get the Rigidbody of the bullet (make sure the bulletPrefab has a Rigidbody component)
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            if (bulletRigidbody != null)
            {
                // Apply force to the bullet in the forward direction
                bulletRigidbody.AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);
                audio_Shoot.GetComponent<AudioSource>().Play();
                // Trigger the shooting animation
                if (animator != null)
                {
                    animator.Play("Shooting", 0, 0f);
                }

                // Destroy the bullet after 2 seconds
                Destroy(bullet, 2f);
            }
            else
            {
                Debug.LogError("Bullet prefab is missing Rigidbody component.");
            }
        }
        else
        {
            Debug.LogError("Gun transform, bullet prefab, or bullet spawn point is not assigned.");
        }
    }


  
}
