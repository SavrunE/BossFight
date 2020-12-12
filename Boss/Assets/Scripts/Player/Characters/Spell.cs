using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spell : MonoBehaviour
{
    [SerializeField] private float staminaCost; 
    public event UnityAction<float> StaminaChanged;

    public void ExpenditureStamina()
    {
        StaminaChanged?.Invoke(staminaCost);
    }
}
