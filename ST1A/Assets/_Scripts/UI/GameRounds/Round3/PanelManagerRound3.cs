using UnityEngine;

public class PanelManagerRound3 : MonoBehaviour
{
    public GameObject[] panelsToDeactivate;
    public Canvas[] canvasesToActivate;

    public void TogglePanels()
    {
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
