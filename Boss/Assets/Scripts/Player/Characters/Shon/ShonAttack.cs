using System.Collections;
using UnityEngine;

public class ShonAttack : AttackCharacter
{
    public AttackSphere Weapon;
    [Range(0.1f, 1f)]
    [SerializeField] private float timeToAttack;
    private void Start()
    {
        Weapon.gameObject.SetActive(false);
    }
    protected override void Attack()
    {
        base.Attack();
        StartCoroutine(Attacker());
    }
    private IEnumerator Attacker()
    {
        Weapon.gameObject.transform.position = Direction.position;
        Weapon.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeToAttack);
        Weapon.gameObject.SetActive(false);
    }
}
