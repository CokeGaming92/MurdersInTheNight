using UnityEngine;

public class RealisticFlickeringLamp : MonoBehaviour
{
    public Material emissiveMaterial;
    public Light spotlight;
    public float minStableIntensity = 2f;
    public float maxStableIntensity = 3f;
    public float flickerIntensity = 5f;
    public float flickerDuration = 0.1f; // Adjust the duration of the flickering
    public float blackoutDuration = 1f;  // Duration of blackout periods

    private float flickerTimer;
    private float blackoutTimer;

    void Start()
    {
        flickerTimer = flickerDuration;
        blackoutTimer = blackoutDuration;
    }

    void Update()
    {
        if (blackoutTimer > 0f)
        {
            // Blackout period
            SetLightIntensity(0f);
            SetEmissiveColor(Color.black);
            blackoutTimer -= Time.deltaTime;
        }
        else
        {
            // Flickering and stable periods
            flickerTimer -= Time.deltaTime;

            if (flickerTimer <= 0f)
            {
                // Time to flicker
                float flickerEmission = Mathf.PingPong(Time.time * Random.Range(1f, 5f), flickerIntensity);
                Color flickerColor = emissiveMaterial.color * Mathf.LinearToGammaSpace(flickerEmission);
                SetEmissiveColor(flickerColor);
                SetLightIntensity(flickerEmission);

                flickerTimer = flickerDuration;
            }
            else
            {
                // Stable period
                float stableEmission = Random.Range(minStableIntensity, maxStableIntensity);
                Color stableColor = emissiveMaterial.color * Mathf.LinearToGammaSpace(stableEmission);
                SetEmissiveColor(stableColor);
                SetLightIntensity(stableEmission);
            }
        }
    }

    void SetEmissiveColor(Color color)
    {
        emissiveMaterial.SetColor("_EmissionColor", color);
    }

    void SetLightIntensity(float intensity)
    {
        spotlight.intensity = intensity;
    }
}