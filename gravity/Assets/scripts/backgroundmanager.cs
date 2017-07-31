using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backgroundmanager : MonoBehaviour {

	public float scrollSpeed = 0.5f;
	private Vector2 Offset;

	// Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
	void Update ()
    { 
		Offset = new Vector2(Time.time * scrollSpeed, 0);
	    GetComponent<Renderer>().material.mainTextureOffset = Offset;﻿
	}
}
