using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBullet : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerVariant>(out PlayerVariant player))
        {
            player.GetComponent<HP>().TakeDamage(damage);
        }
    }
}
