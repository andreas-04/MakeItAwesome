using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemies : MonoBehaviour {

    [SerializeField] float currentHealth, maxHealth = 10f;

    public Rigidbody2D rb;
    public Animator animator;
    public Transform target;
    public Transform enemy;
  


    public SpriteRenderer spriteRenderer;
    

    private void Awake()
    {
        
    }


    private void Start()
    {

        currentHealth = maxHealth;


    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(10); // Subtract 10 health on collision
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy health: " + currentHealth);

        // Check if health drops to zero or below
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy has been defeated!");
        Destroy(GameObject.Find("realEnemy")); // Destroy the enemy object
    }


    private void Update()
    {

        
        


    }

    private void FixedUpdate()
    {
        
    }



    
}