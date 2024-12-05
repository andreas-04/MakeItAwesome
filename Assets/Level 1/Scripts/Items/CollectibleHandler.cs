using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHandler : MonoBehaviour
{
    public Vector2 spawnPos = new Vector2(posX, posY);

    [SerializeField] public static float posX = 0f;
    [SerializeField] public static float posY = 0f;

    //list of possible item spawn points
    /*
        -10,-55
        -21,-55
        -57,-26
        58,-53
        111,-43
        -86,-35
        -46,-21
        -13,-24
        0,-23
        31,-29
        31,-18
        63,-35
        130,-50
        98,-25
    */

    // Start is called before the first frame update
    void Start()
    {
        CollectibleHandler goalitems = GetComponent<GoalItems>();
        CollectibleHandler powerups = GetComponent<Powerups>();
        goalitems.v_InitItems();
        powerups.v_InitItems();
    }

    public virtual void v_InitItems() 
    //public void v_InitItems() 
    {
        //call functions to init goal and powerups
        Debug.Log("init called from CH");
    }

    public void disableItem(GameObject go)
    {
        go.SetActive(false);
    }
}