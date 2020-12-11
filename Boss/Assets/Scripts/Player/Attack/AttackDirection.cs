using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDirection : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private AttackSphere bullet;
    [SerializeField] private Transform direction;
    [Range(0.1f, 2f)]
    [SerializeField] private float delayToAttack;
    [SerializeField] private float bulletSpeed = 10f;
    private bool canAttack;

    private void OnEnable()
    {
        canAttack = true;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && canAttack)
        {
            SetDirection();
            Attack();
        }
    }
    private void SetDirection()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
    }
    private void Attack()
    {
        StartCoroutine(DelayToAttack());
        AttackSphere pojectale = Instantiate(bullet, direction.position, transform.rotation);
        pojectale.GetComponent<Rigidbody2D>().AddForce((direction.position - transform.position).normalized * bulletSpeed);
    }

    private IEnumerator DelayToAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(delayToAttack);
        canAttack = true;
    }
}
