using TMPro;
using UnityEngine;

using System.Collections;

public class AnimatedText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string fullText;
    public float delay = 0.1f;
    public float shakeIntensity = 0.1f;
    public float shakeDuration = 0.05f;
    public AudioClip textSound;
    public float typingSpeed = 1f;

    private Vector3 originalPosition;
    private AudioSource audioSource;

    void Start()
    {
        originalPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            string currentText = fullText.Substring(0, i);
            text.text = currentText;

            // Play text sound
            if (textSound != null)
                audioSource.PlayOneShot(textSound);

            // Shake effect
            StartCoroutine(ShakeText());

            yield return new WaitForSeconds(delay / typingSpeed); // Adjust typing speed
        }
    }

    IEnumerator ShakeText()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float x = originalPosition.x + Random.Range(-shakeIntensity, shakeIntensity);
            float y = originalPosition.y + Random.Range(-shakeIntensity, shakeIntensity);

            transform.position = new Vector3(x, y, originalPosition.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
    }
}