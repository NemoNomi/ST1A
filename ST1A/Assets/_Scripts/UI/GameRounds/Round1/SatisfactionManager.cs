using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SatisfactionManager : MonoBehaviour
{
    [Header("Satisfaction Sliders")]
    public Slider[] satisfactionSliders;

    [Header("Slider Fill Colors")]
    public Color color0 = Color.gray;
    public Color color1_3 = Color.red;
    public Color color2_3 = Color.yellow;
    public Color color3_3 = Color.green;

    [Header("Handle Sprites")]
    public Sprite handleSprite0;
    public Sprite handleSprite1_3;
    public Sprite handleSprite2_3;
    public Sprite handleSprite3_3;

    private float satisfactionDecrement = 1.0f / 3.0f; // One third decrement
    public float fillSpeed = 0.5f; // Speed of the fill animation

    private void Start()
    {
        // Initialize the sliders to full
        foreach (Slider slider in satisfactionSliders)
        {
            slider.value = 1.0f;
            UpdateSliderAppearance(slider);
        }
    }

    public void DecreaseCivilianSatisfaction()
    {
        DecreaseSatisfaction(1); 
    }

    public void DecreaseClimateSatisfaction()
    {
        DecreaseSatisfaction(2);
    }

    public void DecreaseFinanceSatisfaction()
    {
        DecreaseSatisfaction(0); 
    }

    private void DecreaseSatisfaction(int index)
    {
        float targetValue = satisfactionSliders[index].value - satisfactionDecrement;
        if (targetValue < 0.0f)
        {
            targetValue = 0.0f;
        }
        StartCoroutine(AnimateSliderFill(satisfactionSliders[index], targetValue));
    }

    private IEnumerator AnimateSliderFill(Slider slider, float targetValue)
    {
        float startValue = slider.value;
        float elapsedTime = 0;

        while (elapsedTime < fillSpeed)
        {
            slider.value = Mathf.Lerp(startValue, targetValue, elapsedTime / fillSpeed);
            UpdateSliderAppearance(slider);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        slider.value = targetValue;
        UpdateSliderAppearance(slider);
    }

    private void UpdateSliderAppearance(Slider slider)
    {
        // Find the fill image within the slider
        Image fillImage = slider.fillRect.GetComponentInChildren<Image>();
        Image handleImage = slider.handleRect.GetComponentInChildren<Image>();

        if (slider.value == 0.0f)
        {
            fillImage.color = color0;
            handleImage.sprite = handleSprite0;
        }
        else if (slider.value <= 1.0f / 3.0f)
        {
            fillImage.color = color1_3;
            handleImage.sprite = handleSprite1_3;
        }
        else if (slider.value <= 2.0f / 3.0f)
        {
            fillImage.color = color2_3;
            handleImage.sprite = handleSprite2_3;
        }
        else
        {
            fillImage.color = color3_3;
            handleImage.sprite = handleSprite3_3;
        }

        // Update the handle color to match the fill color
        if (handleImage != null)
        {
            handleImage.color = fillImage.color;
        }
    }
}
