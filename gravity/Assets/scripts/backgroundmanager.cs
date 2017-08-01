using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backgroundmanager : MonoBehaviour {

	public float ScrollSpeed = 0.5f;
	private Vector2 _offset;
    
	void Update ()
    { 
		_offset = new Vector2(Time.time * ScrollSpeed, 0);
	    GetComponent<Renderer>().material.mainTextureOffset = _offset;﻿
	}
}
