using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //[SerializeField] private float attackCooldown;
    [SerializeField] private int lightDamage;
    [SerializeField] private int heavyDamage;

    [SerializeField] private LayerMask enemyLayer;


    public SphereCollider AttackPoint;

    //private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private Enemy enemyHealth;

    private int attackDamage;




    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<Enemy>();
    }

    private void Update()
    {
    }

    public void LightAttack(Vector3 attackPosition)
    {
        AttackPoint.enabled = false;
        AttackPoint.transform.localPosition = attackPosition;
        anim.SetTrigger("LightPunch");
        Attack(lightDamage);
    }

    public void HeavyAttack(Vector3 attackPosition)
    {
        AttackPoint.enabled = false;
        AttackPoint.transform.localPosition = attackPosition;
        anim.SetTrigger("HeavyPunch");
        Attack(heavyDamage);
    }

    private void OnDrawGizmos()
    {
        if (AttackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPoint.transform.position, AttackPoint.radius);

    }



    void Attack(int damage)
    {
        attackDamage = damage;
        AttackPoint.enabled = true;
    }

    void EndAttack()
    {
        AttackPoint.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy)
        {
            Debug.Log($"Send TakeDamage {attackDamage}");
            enemy.TakeDamage(attackDamage);
        }
    }
}