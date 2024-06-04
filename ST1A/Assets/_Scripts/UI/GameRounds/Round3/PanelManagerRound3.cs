using UnityEngine;
using System.Collections;

public class PanelManagerRound3 : MonoBehaviour
{
    public GameObject[] panelsToDeactivate;
    public Canvas[] canvasesToActivate;
    public float delayBeforeToggle = 2.0f; // Zeit in Sekunden, die gewartet wird

    public void TogglePanels()
    {
        StartCoroutine(TogglePanelsWithDelay());
    }

    private IEnumerator TogglePanelsWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeToggle);

        foreach (GameObject panel in panelsToDeactivate)
        {
            panel.SetActive(false);
        }

        foreach (Canvas canvas in canvasesToActivate)
        {
            canvas.gameObject.SetActive(true);
        }
    }
}
