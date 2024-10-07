using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHandler : MonoBehaviour
{
    public GoalItems goalitems;

    public void initItems() {
        //call functions to init goal and powerups
        Debug.Log("collectible handler active");
        goalitems.GetComponent<GoalItems>().initGoalItems();
    }



    // Start is called before the first frame update
    void Start()
    {
        initItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
