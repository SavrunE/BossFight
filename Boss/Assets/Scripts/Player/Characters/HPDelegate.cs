using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HPDelegate : MonoBehaviour
{
    public event UnityAction<float> HPChanged;
    public void ChangeHP(float hP)
    {
        HPChanged?.Invoke(hP);
    }
}
