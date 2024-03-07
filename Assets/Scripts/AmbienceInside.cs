using UnityEngine;

public class IndoorAmbienceController : MonoBehaviour
{
    public AudioClip indoorMusic;
    public float maxDistance = 10f;
    public float maxVolume = .45f;
    public float fadeSpeed = 5f;
    public string playerTag = "Player";
    public float fadeOutStartDistance = 5f;
    public float setVolume = 0f; // Initialize setVolume to zero
   [SerializeField] private AudioSource audioSource, audioSource2;
    private GameObject player;
    private bool hasPlayed = false;

    private void Start()
    {   
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = indoorMusic;

       
        audioSource.playOnAwake = false;
        audioSource.volume = 0f;
        audioSource.Play();
        audioSource2.Play();
        player = GameObject.FindGameObjectWithTag(playerTag);
      
    }

    private void Update()
    {
        if (!hasPlayed && IsPlayerInside())
        {
            PlayIndoorMusic();
        }

        if (hasPlayed)
        {
            AdjustVolume();
        }
        
        if(hasPlayed && IsPlayerInside())
        {
            setVolume += 1f * Time.deltaTime;
            // Clamp setVolume to ensure it doesn't exceed the maximum volume
            setVolume = Mathf.Clamp(setVolume, 0f, maxVolume);
       
            audioSource.volume = setVolume;
            audioSource2.volume = 0f;
        }
    }

    private void PlayIndoorMusic()
    {
        audioSource.volume = maxVolume;
      
        hasPlayed = true;
    }

    private void AdjustVolume()
    {
        float distanceToCollider = Vector3.Distance(transform.position, player.transform.position);
        setVolume = audioSource.volume;
        if (distanceToCollider > fadeOutStartDistance)
        {
            setVolume -= 1f * Time.deltaTime;
            // Clamp setVolume to ensure it doesn't exceed the maximum volume
            setVolume = Mathf.Clamp(setVolume, 0f, maxVolume);
            audioSource.volume = setVolume;
        }
        audioSource2.volume = 0.5f;
    }

    private bool IsPlayerInside()
    {
        Collider[] colliders = GetComponents<Collider>();

        if (player != null && colliders.Length > 0)
        {
            foreach (var collider in colliders)
            {
                if (collider.bounds.Contains(player.transform.position))
                {
                    return true;
                }
            }
        }

        return false;
    }
}