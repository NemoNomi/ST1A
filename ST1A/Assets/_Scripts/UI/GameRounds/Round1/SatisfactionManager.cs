using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SatisfactionManager : MonoBehaviour
{
    [Header("Satisfaction Sliders")]
    public Slider[] satisfactionSliders;
    
    [Header("Slider Fill Colors")]
    public Color color1_3 = Color.red;
    public Color color2_3 = Color.yellow;
    public Color color3_3 = Color.green;

    private float satisfactionIncrement = 1.0f / 3.0f; // One third increment
    private float fillSpeed = 0.5f; // Speed of the fill animation

    private void Start()
    {
        // Initialize the sliders
        foreach (Slider slider in satisfactionSliders)
        {
            slider.value = 0;
            UpdateSliderColor(slider);
        }
    }

    public void IncreaseSatisfaction(int buttonIndex)
    {
        // Increment the clicked NPC's satisfaction
        if (buttonIndex >= 0 && buttonIndex < satisfactionSliders.Length)
        {
            float targetValue = satisfactionSliders[buttonIndex].value + satisfactionIncrement;
            if (targetValue > 1.0f)
            {
                targetValue = 1.0f;
            }
            StartCoroutine(AnimateSliderFill(satisfactionSliders[buttonIndex], targetValue));
        }
    }

    private IEnumerator AnimateSliderFill(Slider slider, float targetValue)
    {
        float startValue = slider.value;
        float elapsedTime = 0;

        while (elapsedTime < fillSpeed)
        {
            slider.value = Mathf.Lerp(startValue, targetValue, elapsedTime / fillSpeed);
            UpdateSliderColor(slider);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        slider.value = targetValue;
        UpdateSliderColor(slider);
    }

    private void UpdateSliderColor(Slider slider)
    {
        // Find the fill image within the slider
        Image fillImage = slider.fillRect.GetComponentInChildren<Image>();
        if (slider.value <= 1.0f / 3.0f)
        {
            fillImage.color = color1_3;
        }
        else if (slider.value <= 2.0f / 3.0f)
        {
            fillImage.color = color2_3;
        }
        else
        {
            fillImage.color = color3_3;
        }
    }
}
