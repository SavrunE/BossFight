using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSphere : MonoBehaviour
{
    [SerializeField] private AttackSphere bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform target;

    public void LaunchBullet(Vector3 target)
    {
        AttackSphere pojectale =  Instantiate(bullet, transform.position, Quaternion.identity);
        Debug.Log("start pos " + pojectale.transform.position);
        Debug.Log("end pos " + target);
        pojectale.GetComponent<Rigidbody2D>().AddForce(target.normalized * bulletSpeed);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
        
        }
    }
}

