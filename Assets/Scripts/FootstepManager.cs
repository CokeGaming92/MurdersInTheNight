using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    public AudioClip concreteFootstepSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFootstep(string surface)
    {
        switch (surface)
        {
         
            case "concrete":
                audioSource.PlayOneShot(concreteFootstepSound);
                break;
            default:
                Debug.LogWarning("No footstep sound defined for surface: " + surface);
                break;
        }
    }
}