using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float HP;


    public void SetDamage(float damage)
    {
        HP -= damage;
    }
    public void SetTarget(GameObject target)
    {

    }
}
