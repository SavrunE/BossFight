using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [SerializeField] private float maxEnergy;
    [SerializeField] private float energy;
    [SerializeField] private float energyRecovery;
    [SerializeField] private Slider slider;
    [SerializeField] private Text energyValue;
    [SerializeField] private Spell[] spells;

    private void Start()
    {
        energy = maxEnergy;
        StartCoroutine(StamineRecovery());
        DisplayEnergy();
    }
    private void OnEnable()
    {
        foreach (var spell in spells)
        {
            spell.StaminaChanged += OnChangeStamina;
        }
    }
    private void OnDisable()
    {
        foreach (var spell in spells)
        {
            spell.StaminaChanged -= OnChangeStamina;
        }
    }
    private void OnChangeStamina(float value)
    {
        print("OnChangeStamina " + value);
        energy += value;
        if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }
        DisplayEnergy();
    }
    private IEnumerator StamineRecovery()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            OnChangeStamina(energyRecovery);
        }
    }
    private void DisplayEnergy()
    {
        slider.value = energy;
        energyValue.text = ((int)energy).ToString();
    }
}
