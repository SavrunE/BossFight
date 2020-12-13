using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spell : MonoBehaviour
{
    [Range(0.1f, 2f)]
    [SerializeField] protected float Delay;
    [SerializeField] private float staminaCost;

    public event UnityAction<float> StaminaChanged;
    private void Start()
    {
    }
    public void ExpenditureStamina()
    {
        StaminaChanged?.Invoke(-staminaCost);
    }
}
