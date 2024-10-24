using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHandler : MonoBehaviour
{
    public Vector2 spawnPos = new Vector2(posX, posY);

    [SerializeField] public static float posX = 0f; //i will add functions to randomize this later
    [SerializeField] public static float posY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        CollectibleHandler goalitems = GetComponent<GoalItems>();
        CollectibleHandler powerups = GetComponent<Powerups>();
        goalitems.v_InitItems();
        powerups.v_InitItems();
    }

    public virtual void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("CH collision");
    }

    public virtual void v_InitItems() 
    {
        //call functions to init goal and powerups
        Debug.Log("init called from CH");
    }

    public void disableItem(GameObject go)
    {
        go.SetActive(false);
    }
}