using System.Collections;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{
    public Color startColor = Color.white; // Start color of the GameObject
    public Color blinkColor = Color.red;   // Blink color of the GameObject
    public float blinkInterval = 0.5f;     // Time interval for the blink effect

    private Renderer objectRenderer;       // Renderer of the GameObject
    private bool isBlinking = false;       // Flag to control the blinking effect

    void Start()
    {
        // Get the Renderer component of the GameObject
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            // Start the blinking effect
            StartCoroutine(Blink());
        }
        else
        {
            Debug.LogError("Renderer not found on the GameObject. Please ensure the GameObject has a Renderer component.");
        }
    }

    void Update()
    {
        // Stop the blinking effect if the GameObject is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    StopBlinking();
                }
            }
        }
    }

    /// <summary>
    /// Coroutine to handle the blinking effect.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Blink()
    {
        while (true)
        {
            // Toggle the color between startColor and blinkColor
            objectRenderer.material.color = isBlinking ? startColor : blinkColor;
            isBlinking = !isBlinking;

            // Wait for the specified blink interval
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    /// <summary>
    /// Stops the blinking effect.
    /// </summary>
    private void StopBlinking()
    {
        StopAllCoroutines();
        objectRenderer.material.color = startColor; // Reset to the start color
    }
}
