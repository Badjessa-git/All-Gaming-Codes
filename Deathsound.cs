﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathsound : MonoBehaviour {

    public AudioSource death;

	// Use this for initialization
	void Start () {
      death =  GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            death.Play();
        }
    }
}
