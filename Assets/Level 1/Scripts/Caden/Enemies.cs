using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemies : MonoBehaviour {

    [SerializeField] float health, maxHealth = 10f;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Rigidbody2D rb;
    //public AIPath aiPath;

    private void Awake()
    {
        
    }


    private void Start()
    {
        //Set enemy health when the game starts
        health = maxHealth;
        

        rb = GetComponent<Rigidbody2D>();

        var enemies = GameObject.Find("Enemies").GetComponent<Enemies>();
        var enemy = GameObject.Find("Enemy").GetComponent<Enemies>();
        enemies.transform.parent = enemy.transform;


    }


    private void Update()
    {
        
    }


    private void FixedUpdate()
    {
        
    }



    
}