using UnityEngine;
using System.Collections;

public class PanelManagerRound3 : MonoBehaviour
{
    public GameObject[] panelsToDeactivate;
    public Canvas[] canvasesToActivate;
    public GameObject[] panelsToActivate;
    public float[] delaysBeforeToggle; // Array of delays before each toggle

    public void TogglePanels()
    {
        StartCoroutine(TogglePanelsWithDelay());
    }

    private IEnumerator TogglePanelsWithDelay()
    {
        // Loop through each delay and toggle accordingly
        for (int i = 0; i < delaysBeforeToggle.Length; i++)
        {
            float delay = delaysBeforeToggle[i];
            yield return new WaitForSeconds(delay);

            // Activate specified canvases first
            foreach (Canvas canvas in canvasesToActivate)
            {
                canvas.gameObject.SetActive(true);
            }

            // Deactivate specified panels
            foreach (GameObject panel in panelsToDeactivate)
            {
                panel.SetActive(false);
            }

            // Activate specified panels
            panelsToActivate[i].SetActive(true);
        }
    }
}
