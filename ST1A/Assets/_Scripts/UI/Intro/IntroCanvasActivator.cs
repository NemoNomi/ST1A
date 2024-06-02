using UnityEngine;
using System.Collections;

/// <summary>
/// Activates the intro canvas after a delay when the game starts
/// </summary>
public class IntroCanvasActivator : MonoBehaviour
{
    [Header("Canvas Settings")]
    [Tooltip("The intro canvas to be activated after the delay")]
    public Canvas introCanvas;

    [Header("Activation Settings")]
    [Tooltip("Delay in seconds before the intro canvas is activated")]
    public float activationDelay = 4.0f;

    /// <summary>
    /// Initializes the canvas state and starts the activation coroutine.
    /// </summary>
    private void Start()
    {
        // Ensure the canvas is deactivated at the start
        introCanvas.gameObject.SetActive(false);

        // Start the coroutine to activate the canvas after the delay
        StartCoroutine(ActivateCanvasAfterDelay(activationDelay));
    }

    /// <summary>
    /// Coroutine to activate the canvas after a delay.
    /// </summary>
    /// <param name="delay">The delay in seconds.</param>
    private IEnumerator ActivateCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        introCanvas.gameObject.SetActive(true);
    }
}
