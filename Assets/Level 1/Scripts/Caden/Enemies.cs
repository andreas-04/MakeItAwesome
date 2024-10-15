using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    [SerializeField] float health, maxHealth = 10f;

    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        //Set enemy health when the game starts
        health = maxHealth;
        target = GameObject.Find("Player").transform;
    }


    private void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position-transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }


    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }



    public void EnemyPathing() {
        Debug.Log("Enemy pathing feature coming soon");
    }
}