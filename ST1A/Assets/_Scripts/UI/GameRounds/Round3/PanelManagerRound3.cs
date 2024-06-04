using UnityEngine;
using System.Collections;

public class PanelManagerRound3 : MonoBehaviour
{
    public GameObject[] panelsToDeactivate;
    public Canvas[] canvasesToActivate;
    public GameObject[] panelsToActivate;
    public float delayBeforeToggle = 2.0f;

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

        foreach (GameObject panel in panelsToActivate)
        {
            panel.SetActive(true);
        }
    }
}
