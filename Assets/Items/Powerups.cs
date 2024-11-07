using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : CollectibleHandler
{
    public GameObject water;
    [SerializeField] public float jumpboost = 10f;

    void OnTriggerEnter2D(Collider2D other) 
    {
        //Debug.Log("Collision detected. " + gameObject + "collided with " + other.name);
        if (other.CompareTag("Player")) {
            disableItem(gameObject);
            //Debug.Log("powerup collected :)");
            other.GetComponent<PlayerMovement>().jumpForce += jumpboost;
        }
    }
    
    public override void v_InitItems() 
    //public  void v_InitItems() 
    {
        Instantiate(water, new Vector2(posX-68,posY-29), Quaternion.identity); //-68 -29
    }
}
