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
        //initItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public virtual void initItems() 
    {
        //call functions to init goal and powerups
        //Instantiate(item, item.GetComponent<CollectibleHandler>().spawnPos, Quaternion.identity); 
        Debug.Log("init called from CH");
    }
}