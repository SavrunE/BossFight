using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private Vector3 direction;
    [SerializeField] private bool useRandomSpawner;
    [SerializeField] private float randomSpawnRange;
    [Range(0.1f, 5f)]
    [SerializeField] private float spawnDelay = 1f;
    private void Start()
    {
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            var bullet = Instantiate(spawnObject, transform.position, Quaternion.identity);
            if (bullet.TryGetComponent<Rigidbody2D>(out Rigidbody2D body))
            {
                if (useRandomSpawner == false)
                {
                    body.AddForce(direction, ForceMode2D.Impulse);
                }
                else
                {
                    body.AddForce(new Vector2(direction.x + Random.Range(-randomSpawnRange, randomSpawnRange),
                        direction.y + Random.Range(-randomSpawnRange, randomSpawnRange)),
                        ForceMode2D.Impulse);
                }
            }
        }
    }
}
