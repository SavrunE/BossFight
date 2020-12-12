using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    private GameObject target;
    private void OnEnable()
    {
        target = null;
    }
    public GameObject TakeTargetTrigger()
    {
        return target;
    }
    public void RememberCheckedEnemy(GameObject enemy)
    {
        target = enemy;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(DelayCheck(other));
    }
    private IEnumerator DelayCheck(Collider2D other)
    {
        yield return null;
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            RememberCheckedEnemy(enemy.gameObject);
        }
    }
}
