using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalItems : MonoBehaviour
{
    public Stillsuit stillsuit;

    //function to init each goal item
    public void initGoalItems() {
        Instantiate(stillsuit, stillsuit.GetComponent<Stillsuit>().spawnPos, Quaternion.identity);
    }

    //track items to know if its time to progress

}
