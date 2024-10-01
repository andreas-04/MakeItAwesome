using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LevelAudio();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "LevelExit"){
            Debug.Log("Entering LevelExit");
            SceneManager.LoadScene(1);
        }

    }

    private void LevelAudio(){
        Debug.Log("Joe: Audio Manger Coming Soon");
    }
}
