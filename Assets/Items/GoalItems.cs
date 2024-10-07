using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalItems : MonoBehaviour
{
    public Stillsuit stillsuit;
    public GameManager gm;

    //function to init each goal item
    public void initGoalItems() {
        Instantiate(stillsuit, stillsuit.GetComponent<Stillsuit>().spawnPos, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            //gm.GetComponent<GameManager>().AddToInventory(stillsuit);
            Debug.Log("item collected :)");
        }
    }

}
