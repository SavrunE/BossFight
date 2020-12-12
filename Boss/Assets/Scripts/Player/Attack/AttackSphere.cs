using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AttackSphere : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Debug.Log("Attack enemy " + damage);
        }
        if(collision.TryGetComponent<EnemiesBullet>(out EnemiesBullet enemyBullet))
        {
            Destroy(this.gameObject);
            Destroy(enemyBullet.gameObject);
        }
    }
}
