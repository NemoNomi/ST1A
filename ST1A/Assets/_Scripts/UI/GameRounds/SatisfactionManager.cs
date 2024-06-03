using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the satisfaction level of NPCs in the game over multiple rounds.
/// </summary>
public class SatisfactionManager : MonoBehaviour
{
    [Header("Satisfaction Sliders")]
    public Slider[] satisfactionSliders;

    private float satisfactionIncrement = 1.0f / 3.0f; // One third increment

    private void Start()
    {
        // Initialize the sliders
        foreach (Slider slider in satisfactionSliders)
        {
            slider.value = 0;
        }
    }

    /// <summary>
    /// Method to increase satisfaction for a specific NPC/Slider.
    /// </summary>
    /// <param name="buttonIndex">The index of the clicked button.</param>
    public void IncreaseSatisfaction(int buttonIndex)
    {
        // Increment the clicked NPC's satisfaction
        if (buttonIndex >= 0 && buttonIndex < satisfactionSliders.Length)
        {
            satisfactionSliders[buttonIndex].value += satisfactionIncrement;
            if (satisfactionSliders[buttonIndex].value > 1.0f)
            {
                satisfactionSliders[buttonIndex].value = 1.0f;
            }
        }
    }
}
