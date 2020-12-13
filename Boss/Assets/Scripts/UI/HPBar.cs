using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private HPDelegate characterHP;
    [SerializeField] private Slider slider;
    [SerializeField] private Text hPValue;

    private void OnEnable()
    {
        characterHP.HPChanged += DisplayEnergy;
    }
    private void OnDisable()
    {
        characterHP.HPChanged -= DisplayEnergy;
    }
    private void DisplayEnergy(float hP)
    {
        slider.value = hP;
        hPValue.text = ((int)hP).ToString();
    }
}
