using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCharacter : MonoBehaviour
{
    public Transform Direction;
    [Range(0.1f, 2f)]
    [SerializeField] protected float delayToAttack;
    protected bool canAttack;

    protected void OnEnable()
    {
        canAttack = true;
    }
    protected void Update()
    {
        if (Input.GetMouseButton(0) && canAttack)
        {
            SetDirection();
            Attack();
        }
    }
    protected void SetDirection()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }
    protected virtual void Attack()
    {
        StartCoroutine(DelayToAttack());
    }

    protected IEnumerator DelayToAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(delayToAttack);
        canAttack = true;
    }
}
