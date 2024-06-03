using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject[] panelsToDeactivate;
    public GameObject[] panelsToActivate;

    public void TogglePanels()
    {
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
