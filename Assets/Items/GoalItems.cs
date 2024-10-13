using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalItems : CollectibleHandler
{
    public GameObject stillsuit; //singular item temporarily
    public GameObject tent;
    public GameObject knife;
    public GameObject hooks;



    //function to init each goal item
    void initItems() {
        //Instantiate(stillsuit, GetComponent<CollectibleHandler>().spawnPos, Quaternion.identity); //red
        Instantiate(stillsuit, new Vector2(-2,0), Quaternion.identity); //red
        Instantiate(tent, new Vector2(2,0), Quaternion.identity); //black
        Instantiate(knife, new Vector2(2,-2), Quaternion.identity); //green
        Instantiate(hooks, new Vector2(-2,2), Quaternion.identity); //white
    }

    void Start() {
        initItems();
    }

    /*void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            //gm.GetComponent<GameManager>().AddToInventory(stillsuit);
            Debug.Log("item collected :)");
        }
    }*/

}
