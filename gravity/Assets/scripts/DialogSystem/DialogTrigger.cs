﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private GameManager _theGameManager;
    private DialogUIController _dialogUIController;
    public int DialogIndex;

    private void Start()
    {
        _dialogUIController = FindObjectOfType<DialogUIController>();
        _theGameManager = GameManager.TheGameManager;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            _dialogUIController.OpenDialog(DialogIndex);
            _theGameManager.WorldPause();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _dialogUIController.OpenDialog(DialogIndex);
    }
}