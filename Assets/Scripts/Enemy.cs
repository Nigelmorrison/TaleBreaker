using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int startingHealth;

    public int currentHealth;
    public Animator anim;
    private Camera mainCamera;

    void Start()
    {
        currentHealth = startingHealth;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera != null)
        {
            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up); // makes the enemy sprite lok at camera
        }
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
            Destroy(gameObject);
        }


    }
}