using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSphereShon : AttackSphere
{
    private ShonAttack parent;
    private void Start()
    {
        parent = transform.parent.GetComponent<ShonAttack>();
    }
    private void Update()
    {
        parent.Weapon.gameObject.transform.position = parent.Direction.gameObject.transform.position;
    }
}
