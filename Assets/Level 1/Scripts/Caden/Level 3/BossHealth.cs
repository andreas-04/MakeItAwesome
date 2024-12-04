using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public int health = 500;

    public GameObject deathEffect;

    public bool isInvulnerable = false;

    public BossHealthScript healthbar;

    void Start()
    {
        healthbar.SetMaxHealth(health);
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;
        healthbar.SetHealth(health);//

        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}