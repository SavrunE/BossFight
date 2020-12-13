using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float HP;


    public void SetDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void SetTarget(GameObject target)
    {

    }
}
