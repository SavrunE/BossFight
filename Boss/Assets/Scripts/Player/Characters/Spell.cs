using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spell : MonoBehaviour
{
    [Range(0.1f, 10f)]
    [SerializeField] protected float delay;
    [SerializeField] private float energyCost;

    public event UnityAction<float> StaminaChanged;
    private void Start()
    {
    }
    public void ExpenditureStamina()
    {
        StaminaChanged?.Invoke(-energyCost);
    }
}
