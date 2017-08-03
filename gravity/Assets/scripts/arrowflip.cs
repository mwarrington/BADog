using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowflip : MonoBehaviour, iPausable
{
    private Transform _dogpos;
    private bool _paused = false;

    public void TogglePause()
    {
        _paused = !_paused;
    }

    void Start ()
	{
	    _dogpos = GameObject.Find("playerdog").transform;
	}
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_paused)
        {
            transform.Rotate(180f, 0f, 0f);
        }

        if (transform != null && _dogpos != null)
        {
            transform.position = new Vector3(transform.position.x, _dogpos.position.y, transform.position.z);
        }
    }
}
