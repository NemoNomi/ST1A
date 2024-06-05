using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public Canvas[] canvasesToDeactivate;
    public Canvas[] canvasesToActivate;
    public GameObject[] panelsToDeactivate;
    public GameObject[] panelsToActivate;

    public void ToggleCanvasesAndPanels()
    {
        // Deactivate specified canvases
        foreach (Canvas canvas in canvasesToDeactivate)
        {
            canvas.gameObject.SetActive(false);
        }

        // Activate specified canvases
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
        foreach (GameObject panel in panelsToActivate)
        {
            panel.SetActive(true);
        }
    }
}
