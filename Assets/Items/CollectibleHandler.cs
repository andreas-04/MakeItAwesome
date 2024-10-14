using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHandler : MonoBehaviour
{
    [SerializeField] static float posX = 0f; //i will add functions to randomize this later
    [SerializeField] static float posY = 0f;

    public Vector2 spawnPos = new Vector2(posX, posY);
 
    public virtual void initItems() {
        //call functions to init goal and powerups
        //Instantiate(item, item.GetComponent<CollectibleHandler>().spawnPos, Quaternion.identity); 
        Debug.Log("init called from CH");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Debug.Log("item collision");
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        //initItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
