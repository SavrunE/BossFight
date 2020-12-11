using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSphere : MonoBehaviour
{
    [SerializeField] private AttackSphere bullet;
    [SerializeField] private float bulletSpeed;
    private Vector3 MousePos;

    public void LaunchBullet(Vector3 target)
    {
        AttackSphere pojectale =  Instantiate(bullet, transform.position, Quaternion.identity);
        pojectale.GetComponent<Rigidbody2D>().AddForce(target - transform.position * bulletSpeed);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            MousePos = Input.mousePosition;
            LaunchBullet(MousePos);
        }
    }
}

