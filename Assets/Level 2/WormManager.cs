using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float distanceBetween = .2f;
    [SerializeField] float speed = 280; 
    [SerializeField] float turnSpeed = 180;
    [SerializeField] List<GameObject> bodyParts = new List<GameObject>();
    List<GameObject> wormBody = new List<GameObject>();

    float countUp = 0;

    void Start()
    {
        CreateBodyParts();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(bodyParts.Count > 0){
            CreateBodyParts();
        }
        WormMovement();
    }
    void WormMovement(){
        wormBody[0].GetComponent<Rigidbody2D>().velocity = wormBody[0].transform.right * speed * Time.deltaTime;
        if (Input.GetAxis("Horizontal") != 0)
            wormBody[0].transform.Rotate(new Vector3(0 ,0, -turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal")));
        if(wormBody.Count > 1)
        {
            for(int i = 1; i < wormBody.Count; i++)
            {
                MarkerManager markM = wormBody[i-1].GetComponent<MarkerManager>();
                wormBody[i].transform.position = markM.markerList[0].position;
                wormBody[i].transform.rotation = markM.markerList[0].rotation;
                markM.markerList.RemoveAt(0);
            }
        }
    }

    void CreateBodyParts()
    {
        if(wormBody.Count == 0){
            GameObject temp = Instantiate(bodyParts[0], transform.position, transform.rotation, transform);
            if(!temp.GetComponent<MarkerManager>())
                temp.AddComponent<MarkerManager>();
            if(!temp.GetComponent<Rigidbody2D>()){
                temp.AddComponent<Rigidbody2D>();
                temp.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            wormBody.Add(temp);
            bodyParts.RemoveAt(0);
        }
        MarkerManager markM = wormBody[wormBody.Count - 1].GetComponent<MarkerManager>();
        if (countUp == 0){
            markM.ClearMarkerList();
        }
        countUp += Time.deltaTime;
        if(countUp >= distanceBetween)
        {
            GameObject temp1 =  Instantiate(bodyParts[0], markM.markerList[0].position, markM.markerList[0].rotation, transform) ;
            if(!temp1.GetComponent<MarkerManager>())
                temp1.AddComponent<MarkerManager>();
            if(!temp1.GetComponent<Rigidbody2D>()){
                temp1.AddComponent<Rigidbody2D>();
                temp1.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            wormBody.Add(temp1);
            bodyParts.RemoveAt(0);
            temp1.GetComponent<MarkerManager>().ClearMarkerList();
            countUp = 0;
        }
    }
}
