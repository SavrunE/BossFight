using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public bool CanTakeDamage;
    [SerializeField] private float maxHP;
    [SerializeField] private float currentHP;
    [SerializeField] private float hPRecovery;

    private HPDelegate hPdelegate;


    private void Start()
    {
        CanTakeDamage = true;
        hPdelegate = transform.parent.GetComponent<HPDelegate>();
        currentHP = maxHP;
        StartCoroutine(HPRecovery());
        hPdelegate.ChangeHP(currentHP);
    }
    public void TakeDamage(float value)
    {
        if (CanTakeDamage)
        {
            OnHPChanged(-value);
        }
    }
    public void OnHPChanged(float value)
    {
        print("OnHPChanged " + value);
        currentHP += value;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        if (currentHP < 0)
        {
            SceneManager.LoadScene(0);
        }
        hPdelegate.ChangeHP(currentHP);
    }
    private IEnumerator HPRecovery()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            OnHPChanged(hPRecovery);
        }
    }
  
}
