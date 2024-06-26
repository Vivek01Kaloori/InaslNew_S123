using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttonfade : MonoBehaviour
{
    public float fadeDuration = 1.0f; // Duration of the fade effect in seconds
    public Light spotLight; // Reference to the spotlight object

    private CanvasGroup canvasGroup;
    private Button button;

    void Start()
    {
        // Get the CanvasGroup component attached to the button
        canvasGroup = GetComponent<CanvasGroup>();

        // Get the Button component and add the OnClick listener
        button = GetComponent<Button>();
        button.onClick.AddListener(FadeOut);

        // Ensure the spotlight is initially disabled
        if (spotLight != null)
        {
            spotLight.enabled = false;
        }
    }

    // Method to fade out the button
    public void FadeOut()
    {
        // Start the coroutine to handle the fading
        StartCoroutine(FadeOutCoroutine());
    }

    // Coroutine to fade out the button over time
    private IEnumerator FadeOutCoroutine()
    {
        float elapsed = 0f;
        float initialAlpha = canvasGroup.alpha;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(initialAlpha, 0f, elapsed / fadeDuration);
            yield return null;
        }

        // Ensure alpha is set to 0 at the end
        canvasGroup.alpha = 0f;
        
        // Disable the button after fade out
        button.interactable = false;

        // Enable the spotlight
        if (spotLight != null)
        {
            spotLight.enabled = true;
        }
    }
}
