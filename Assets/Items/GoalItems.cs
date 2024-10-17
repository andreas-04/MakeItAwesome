using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalItems : CollectibleHandler
{
    public GameObject stillsuit; //singular item temporarily
    public GameObject tent;
    public GameObject knife;
    public GameObject hooks;

    void Start() 
    {
        initItems();
    }

    //function to init each goal item
    void initItems() 
    {
        //Instantiate(stillsuit, GetComponent<CollectibleHandler>().spawnPos, Quaternion.identity); //red
        Instantiate(stillsuit, new Vector2(posX,posY), Quaternion.identity); //red //Random.Range(-2,2),Random.Range(-2,2)
        Instantiate(tent, new Vector2(posX+11,posY), Quaternion.identity); //black
        Instantiate(knife, new Vector2(posX+3,posY+3), Quaternion.identity); //green
        Instantiate(hooks, new Vector2(posX-2,posY-3), Quaternion.identity); //white
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) {
            //gm.GetComponent<GameManager>().AddToInventory(other); //theoretically, other represents the trigger player collided with
            Debug.Log("item collected :)");
        }
        Debug.Log("collision with" + other.name);
    }

}
