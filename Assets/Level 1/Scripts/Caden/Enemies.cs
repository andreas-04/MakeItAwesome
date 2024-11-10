using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemies : MonoBehaviour {

    [SerializeField] float health, maxHealth = 10f;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    

    private void Awake()
    {
        
    }


    private void Start()
    {
        //Set enemy health when the game starts
        health = maxHealth;
        

        rb = GetComponent<Rigidbody2D>();

        
        var enemy = GameObject.Find("Enemy").GetComponent<Enemies>();
        var player = GameObject.Find("Player").GetComponent<PlayerMovement>();



    }


    private void Update()
    {

        



    }

    private void FixedUpdate()
    {
        
    }



    
}