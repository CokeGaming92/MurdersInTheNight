using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Suburb
{

    public class SimplePlayerUse : MonoBehaviour
    {
        public GameObject mainCamera;
      //  private GameObject objectClicked;
     //   public GameObject flashlight;
        public KeyCode OpenClose;
     //   public KeyCode Flashlight;
//	public KeyCode Escape;
//	public AudioSource FlashlightSound;
 //   	public AudioClip[] Flashlight_OnOff;
//	public bool isFlashlightOn;

   //     public Image crossHair;
   //     public GameObject UIPause;

    //    public bool hideCrosshair;
        public float raycastDistance = 10f;


        void Start()
        {

      //      crossHair.gameObject.tag = "Reticle";
          //  Cursor.lockState = CursorLockMode.Locked;
          //  Cursor.visible = false;
        }

        void Update()
        {


            if (Input.GetKeyDown(OpenClose)) // Open and close action
            {
                RaycastCheck();
            }
/*
            if (Input.GetKeyDown(Flashlight)) // Toggle flashlight
            {
                isFlashlightOn = !isFlashlightOn;

                if (isFlashlightOn == true)
                {
                    flashlight.SetActive(true);
                    FlashlightSound.clip = Flashlight_OnOff[0];
                    FlashlightSound.Play();
                }
                if (isFlashlightOn == false)
                {
                    flashlight.SetActive(false);
                    FlashlightSound.clip = Flashlight_OnOff[1];
                    FlashlightSound.Play();
                }

            }

            if (Input.GetKeyDown(Escape)) // Exit game
            {

                hideCrosshair = !hideCrosshair;

                if (hideCrosshair == true)
                {
                    UIPause.SetActive(true);
                    crossHair.enabled = false;

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                if (hideCrosshair == false)
                {

                    UIPause.SetActive(false);
                    crossHair.enabled = true;

                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }

            


        }
*/
        }

        public void EscapeGame()
        {
             SceneManager.LoadScene(0);
        }

        void RaycastCheck()
        {
            RaycastHit hit;
            // Cast a ray from the camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);



           
          
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, 2f))
            {

                // Draw the ray in the Scene view for debugging purposes
                Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.green);

                // Do something with the hit information (e.g., log the name of the object hit)
                Debug.Log("Hit object: " + hit.collider.gameObject.name);
                if (hit.collider.gameObject.GetComponent<SimpleOpenClose>())
                {
                    // Debug.Log("Object with SimpleOpenClose script found");
                    hit.collider.gameObject.BroadcastMessage("ObjectClicked");
                }
                if (hit.collider.gameObject.GetComponent<DoorController>())
                {
                    // Debug.Log("Object with SimpleOpenClose script found");
                    hit.collider.gameObject.BroadcastMessage("ObjectClicked");
                }



                else
                {
                    // Draw the ray in the Scene view for debugging purposes
                    Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);
                }
                // Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                // Debug.Log("Did Hit");
            }
            else
            {
                // Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                //   Debug.Log("Did not Hit");


            }
          
        }

    }
}
