using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backgroundmanager : MonoBehaviour, iPausable {

    private GameManager _theGameManager;
	public float ScrollSpeed = 0.5f;
	private Vector2 _offset;
    private bool _paused;

    private void Start()
    {
        _theGameManager = GameManager.TheGameManager;
        _theGameManager.AddToPausables(this);
    }

    public void TogglePause()
    {
        _paused = !_paused;
    }

    void Update ()
    {
        if (!_paused)
        {
            _offset = new Vector2(Time.time * ScrollSpeed, 0);
            GetComponent<Renderer>().material.mainTextureOffset = _offset;
        }
	}
}
