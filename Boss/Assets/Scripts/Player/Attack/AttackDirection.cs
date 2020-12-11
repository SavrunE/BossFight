using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDirection : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private AttackSphere bullet;
    [SerializeField] private Transform direction;
    [SerializeField] private float delayToAttack;
    [SerializeField] private float startTime;
    [SerializeField] private float bulletSpeed = 10f;

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        if (Input.GetMouseButton(0))
        {
            AttackSphere pojectale = Instantiate(bullet, direction.position, transform.rotation);
          
            pojectale.GetComponent<Rigidbody2D>().AddForce((direction.position - transform.position).normalized * bulletSpeed);
        }
    }
}
