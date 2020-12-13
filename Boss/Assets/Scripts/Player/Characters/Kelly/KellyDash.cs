using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KellyDash : Spell
{
    [SerializeField] private float dashDistance;
    [SerializeField] private TriggerCheck dashTrigger;
    private Mover mover;

    private void Start()
    {
        mover = GetComponent<Mover>();
    }
    void Update()
    {
        if (canUseSpell && Input.GetKeyDown(KeyCode.E))
        {
            ExpenditureStamina();
            StartCoroutine(DashDelayTimer());
            if (mover.LookOnLeft)
            {
                Dash(-1);
            }
            else
            {
                Dash(1);
            }
        }
    }
    private IEnumerator DashDelayTimer()
    {
        canUseSpell = false;
        yield return new WaitForSeconds(Delay);
        canUseSpell = true;
    }

    private void Dash(int direction)
    {
        transform.Translate(new Vector3(direction, 0, 0).normalized * dashDistance, Space.Self);
        StartCoroutine(ActivateDash());

    }
 
    private IEnumerator ActivateDash()
    {
        dashTrigger.gameObject.SetActive(true);
        yield return new WaitForFixedUpdate();
        yield return null;
        GameObject target = dashTrigger.TakeTargetTrigger();
        if (target != null)
        {
            float fightersScale = target.transform.localScale.x / 2 + transform.localScale.x / 2;
            if (mover.LookOnLeft)
            {
                ChangePositionAfterEnemy(target, -fightersScale);
            }
            else
            {
                ChangePositionAfterEnemy(target, fightersScale);
            }
        }
        dashTrigger.gameObject.SetActive(false);
    }
    private void ChangePositionAfterEnemy(GameObject target, float direction)
    {
        transform.position = new Vector3(target.transform.position.x + direction,
                     transform.position.y,
                     transform.position.z);
    }
}
