using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boris : Boss
{
    [SerializeField] private bool isStunned;
    public void TakeDamage(float damage, GameObject target)
    {
        HP -= damage;
        if (isStunned == false && Random.Range(0, 100) > 80)
        {
            RunAttack(target);
        }
    }
    public void SetTarget(GameObject target)
    {

    }
    public void RunAttack(GameObject target)
    {
        print("DamageAttack");
    }
}
