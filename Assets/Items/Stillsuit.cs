using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stillsuit : MonoBehaviour
{
    [SerializeField] static float posX = 0f; //i will add functions to randomize this later
    [SerializeField] static float posY = 0f;

    public Vector2 spawnPos = new Vector2(posX, posY);

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            //do stuff
        }
    }
}
