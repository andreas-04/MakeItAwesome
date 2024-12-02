using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWormManager : MonoBehaviour
{
    [SerializeField] protected List<GameObject> bodyParts = new List<GameObject>();
    [SerializeField] protected float distanceBetween = .2f;
    protected List<GameObject> wormBody = new List<GameObject>();
    protected float countUp = 0;


    // Virtual method for dynamic binding
    protected virtual void CreateBodyParts()
    {
        if (wormBody.Count == 0)
        {
            GameObject temp = Instantiate(bodyParts[0], transform.position, transform.rotation, transform);
            if (!temp.GetComponent<MarkerManager>())
                temp.AddComponent<MarkerManager>();
            if (!temp.GetComponent<Rigidbody2D>())
            {
                temp.AddComponent<Rigidbody2D>();
                temp.GetComponent<Rigidbody2D>().gravityScale = 0;
                temp.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            }
            wormBody.Add(temp);
            bodyParts.RemoveAt(0);
        }

        MarkerManager markM = wormBody[wormBody.Count - 1].GetComponent<MarkerManager>();
        if (countUp == 0)
        {
            markM.ClearMarkerList();
        }
        countUp += Time.deltaTime;

        if (countUp >= distanceBetween)
        {
            AddBodyPart(markM);
        }
    }
    protected void AddBodyPart(MarkerManager markM)
    {
        GameObject temp1 = Instantiate(bodyParts[0], markM.markerList[0].position, markM.markerList[0].rotation, transform);
        if (!temp1.GetComponent<MarkerManager>())
            temp1.AddComponent<MarkerManager>();
        if (!temp1.GetComponent<Rigidbody2D>())
        {
            temp1.AddComponent<Rigidbody2D>();
            temp1.GetComponent<Rigidbody2D>().gravityScale = 0;
            temp1.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
        wormBody.Add(temp1);
        bodyParts.RemoveAt(0);
        temp1.GetComponent<MarkerManager>().ClearMarkerList();
        countUp = 0;
    }

}

// Derived class that overrides CreateBodyParts
public class WormManager : BaseWormManager
{
    [SerializeField] float speed = 280;
    [SerializeField] float turnSpeed = 180;


    void Start()
    {
        // CreateBodyParts();
    }

    void FixedUpdate()
    {
        // if (bodyParts.Count > 0)
        // {
        //     CreateBodyParts();
        // }
        // WormMovement();
    }

    void WormMovement()
    {
        wormBody[0].GetComponent<Rigidbody2D>().velocity = wormBody[0].transform.right * speed * Time.deltaTime;
        if (Input.GetAxis("Horizontal") != 0)
            wormBody[0].transform.Rotate(new Vector3(0, 0, -turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal")));
        if (wormBody.Count > 1)
        {
            for (int i = 1; i < wormBody.Count; i++)
            {
                MarkerManager markM = wormBody[i - 1].GetComponent<MarkerManager>();
                wormBody[i].transform.position = markM.markerList[0].position;
                wormBody[i].transform.rotation = markM.markerList[0].rotation;
                markM.markerList.RemoveAt(0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            Debug.Log("Water");
            AddBodyPart(wormBody[wormBody.Count - 1].GetComponent<MarkerManager>());
            collision.gameObject.GetComponent<WaterManager>().SpawnNewWater();
        }
    }


    // protected override void CreateBodyParts()
    // {
    //     if (bodyParts.Count < 2 || bodyParts[0] == null || bodyParts[1] == null)
    //     {
    //         Debug.LogError("Please assign at least two valid prefabs to 'bodyParts' in the Inspector.");
    //         return;
    //     }

    //     while (wormBody.Count < 2)
    //     {
    //         GameObject newSegment = Instantiate(bodyParts[0], transform.position, transform.rotation, transform);
    //         if (!newSegment.GetComponent<MarkerManager>())
    //             newSegment.AddComponent<MarkerManager>();
    //         if (!newSegment.GetComponent<Rigidbody2D>())
    //         {
    //             var rb = newSegment.AddComponent<Rigidbody2D>();
    //             rb.gravityScale = 0;
    //             rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    //         }

    //         wormBody.Add(newSegment);
    //         bodyParts.RemoveAt(0);

    //         newSegment.GetComponent<MarkerManager>().ClearMarkerList();
    //     }
    // }

}
