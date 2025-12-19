using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //[SerializeField] private float attackCooldown;
    [SerializeField] private int damage;

    [SerializeField] private LayerMask enemyLayer;


    public SphereCollider AttackPoint;

    //private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private Enemy enemyHealth;




    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Punch");
            Attack();
            Debug.Log("attacking");
        }
    }

    private void OnDrawGizmos()
    {
        if (AttackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPoint.transform.position, AttackPoint.radius);

    }



    void Attack()
    {
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
            Debug.Log($"Send TakeDamage {damage}");
            enemy.TakeDamage(damage);
        }
    }
}