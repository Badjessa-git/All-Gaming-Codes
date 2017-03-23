using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    public bool playerInZone;

    public string levelToLoad;
	// Use this for initialization
	void Start () {
        playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
       
            
        
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
            playerInZone = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInZone = false;
        }
    }

}
