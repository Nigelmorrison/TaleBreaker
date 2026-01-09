using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    [SerializeField] private Spawner spawner;

    public int currentHealth;
    public Animator anim;

    void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //hurt animation
            //invulnerability
        }

        else
        {
            //die animation
            Debug.Log("Enemy Dead!");
            spawner.NewEnemy();
            Destroy(gameObject);
        }


    }

    internal void SetSpawner(Spawner spawner)
    {
        this.spawner = spawner;
    }
}