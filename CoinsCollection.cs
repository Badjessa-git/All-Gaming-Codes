using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollection : MonoBehaviour {

    private LevelManager gameLevelManager;
    public AudioSource coins;
   
   
    public int coinValue;
	// Use this for initialization
	void Start () {
        gameLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameLevelManager.AddCoins(coinValue);

            coins.Play();
            Destroy(gameObject);
        }
    }
}
