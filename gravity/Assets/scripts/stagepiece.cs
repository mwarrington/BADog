using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stagepiece : MonoBehaviour, iPausable
{
    private GameManager _theGameManager;
    private bool _paused = false;
    public float MovementSpeed = 3;

    public void TogglePause()
    {
        _paused = !_paused;
    }

    // Use this for initialization
    void Start()
    {
        _theGameManager = GameManager.TheGameManager;
        _theGameManager.AddToPausables(this);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!_paused)
            transform.Translate(Vector3.left * Time.deltaTime * MovementSpeed, Space.World);
    }
}
