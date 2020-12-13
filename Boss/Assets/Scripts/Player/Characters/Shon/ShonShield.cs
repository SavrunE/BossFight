using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShonShield : Spell
{
    [SerializeField] private Shield shield;
    [SerializeField] private float duration;

    private bool canUseSpell;
    private HP hP;
    private void OnEnable()
    {
        shield.gameObject.SetActive(false);
        canUseSpell = true;
    }
    private void Start()
    {
        hP = GetComponent<HP>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canUseSpell)
        {
            StartCoroutine(ShieldDelayTimer());
            StartCoroutine(ActivateShield());
        }
    }
    private IEnumerator ShieldDelayTimer()
    {
        canUseSpell = false;
        yield return new WaitForSeconds(delay);
        canUseSpell = true;
    }
    private IEnumerator ActivateShield()
    {
        Actevater(true);

        yield return new WaitForSeconds(duration);

        Actevater(false);
    }
    private void Actevater(bool value)
    {
        shield.gameObject.SetActive(value);
        hP.CanTakeDamage = !value;
    }
}
