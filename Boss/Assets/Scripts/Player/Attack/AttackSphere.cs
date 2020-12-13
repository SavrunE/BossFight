using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AttackSphere : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private bool canBeDestroyed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.SetDamage(damage);
            if (canBeDestroyed)
            {
                Destroy(this.gameObject);
            }
        }
        //if(collision.TryGetComponent<EnemiesBullet>(out EnemiesBullet enemyBullet))
        //{
        //    Destroy(enemyBullet.gameObject);

        //    if (canBeDestroyed)
        //    {
        //        Destroy(this.gameObject);
        //    }
        //}
    }
}
