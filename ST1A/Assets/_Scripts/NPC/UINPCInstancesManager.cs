using UnityEngine;
using TMPro;
using System.Collections;

#region Class Definition
/// <summary>
/// Manages UI messages.
/// </summary>
public class UINPCInstancesManager : MonoBehaviour
{
    #region Fields
    public GameObject messagePanel; // The panel containing the TextMesh Pro UI element
    #endregion

    #region Public Methods
    /// <summary>
    /// Activates the message panel in the UI.
    /// </summary>
    public void ShowMessage()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(true); // Activate the panel
            StartCoroutine(ClearMessageAfterDelay(3f));
        }
    }

    /// <summary>
    /// Clears the message after a delay.
    /// </summary>
    /// <param name="delay">The delay in seconds before clearing the message.</param>
    /// <returns>IEnumerator for coroutine.</returns>
    private IEnumerator ClearMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messagePanel.SetActive(false); // Deactivate the panel
    }
    #endregion
}
#endregion
