using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalItems : CollectibleHandler
{
    public GameObject stillsuit;
    public GameObject tent;
    public GameObject knife;
    public GameObject hooks;
    private int itemsCollected = 0;

    void OnTriggerEnter2D(Collider2D other) //enemies also trigger collisions so thats good to know 
    {
        if (other.CompareTag("Player")) {
            //gm.GetComponent<GameManager>().AddToInventory(this);
            disableItem(gameObject);
            itemsCollected++;
            //Debug.Log("item collected: " + gameObject + "num collected: " + itemsCollected);
        }
    }

    //function to init each goal item
    public override void v_InitItems() 
    //public  void v_InitItems() 
    {
        //Instantiate(stillsuit, GetComponent<CollectibleHandler>().spawnPos, Quaternion.identity); //red
        Instantiate(stillsuit, new Vector2(posX-10,posY-55), Quaternion.identity); //red -10 -55
        Instantiate(tent, new Vector2(posX+58,posY-53), Quaternion.identity); //black 58 -53
        Instantiate(knife, new Vector2(posX+111,posY-43), Quaternion.identity); //green 111 -43
        Instantiate(hooks, new Vector2(posX-86,posY-35), Quaternion.identity); //white -86 -35
    } 

}
