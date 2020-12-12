using UnityEngine;

public class KellyAttack : AttackCharacter
{
    [SerializeField] protected AttackSphere bullet;
    [SerializeField] protected float bulletSpeed = 10f;
    protected override void Attack()
    {
        base.Attack();

        AttackSphere pojectale = Instantiate(bullet, Direction.position, transform.rotation);
        pojectale.GetComponent<Rigidbody2D>().AddForce((Direction.position - transform.position).normalized * bulletSpeed);
    }
}
