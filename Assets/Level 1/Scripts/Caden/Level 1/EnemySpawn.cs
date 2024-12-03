using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] float health, maxHealth = 10f;

    public Rigidbody2D rb;
    public Animator animator;
    public float speed = 3f;
    public Transform target;
    public Transform enemy;
    public Transform realEnemy;


    public SpriteRenderer spriteRenderer;


    private void Awake()
    {

    }


    private void Start()
    {

        //Set enemy health when the game starts
        health = maxHealth;


        spawnEnemy();


    }


    public void spawnEnemy()
    {
        rb = GetComponent<Rigidbody2D>();


        var enemy = GameObject.Find("Enemy").GetComponent<Enemies>();
        var target = GameObject.Find("Player").GetComponent<PlayerMovement>();
        GameObject realEnemy = Instantiate(GameObject.Find("Enemy"), new Vector3(-86.3f, -34.79f, 0), transform.rotation);
    }


    private void Update()
    {





    }

    private void FixedUpdate()
    {

    }




}