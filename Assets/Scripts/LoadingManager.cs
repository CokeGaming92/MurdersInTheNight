using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public string sceneToLoad;
    public Slider loadingSlider;
    public Image background; // Attach a UI image for the background
    public float fadeDuration = 1.0f;

    void Start()
    {
        StartCoroutine(StartScene());
    }

    IEnumerator StartScene()
    {
        // Set initial background transparency
        Color bgColor = background.color;
        bgColor.a = 0.0f;
        background.color = bgColor;

        // Fade in the background
        yield return StartCoroutine(FadeImage(0.0f, 1.0f, fadeDuration));

        // Load scene
        yield return StartCoroutine(LoadSceneAsync());

        // Optionally, you can perform additional actions after loading

        // Fade out the background
        yield return StartCoroutine(FadeImage(1.0f, 0.0f, fadeDuration));

        // Optionally, you can disable or destroy the loading scene GameObject
        Destroy(gameObject);
    }

    IEnumerator FadeImage(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0.0f;
        Color color = background.color;

        while (elapsedTime < duration)
        {
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            background.color = color;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        color.a = endAlpha;
        background.color = color;
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            loadingSlider.value = progress; // Update the UI loading bar.
            yield return null;
        }
    }
}