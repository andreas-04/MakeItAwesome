using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "LevelExit1"){
            Debug.Log("Entering LevelExit");
            SceneManager.LoadScene(1);
        }
        if(other.tag == "LevelExit2"){
            Debug.Log("Entering LevelExit");
            SceneManager.LoadScene(2);
        }
        if(other.tag == "LevelExit3"){
            Debug.Log("Entering LevelExit");
            SceneManager.LoadScene(3);
        }

    }

}
