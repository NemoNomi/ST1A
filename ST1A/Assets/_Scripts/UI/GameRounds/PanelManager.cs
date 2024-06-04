using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour
{
    public GameObject[] panelsToDeactivate;
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

        foreach (GameObject panel in panelsToActivate)
        {
            panel.SetActive(true);
        }
    }
}
