using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private List<iPausable> _pausables;
    private DialogUIController _dialogUIController;
    public int DialogIndex;

    private void Start()
    {
        _dialogUIController = FindObjectOfType<DialogUIController>();
        _pausables = new List<iPausable>();
        //HACK: ADD THIS TO EVENTAL GAME MANAGER
        _pausables.Add((iPausable)FindObjectOfType<stagemanager>());
        _pausables.Add((iPausable)FindObjectOfType<playergravity>());
        _pausables.Add((iPausable)FindObjectOfType<stagepiece>());
        _pausables.Add((iPausable)FindObjectOfType<arrowflip>());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            WorldPause();
        }
    }

    private void WorldPause()
    {
        foreach (iPausable ip in _pausables)
        {
            ip.TogglePause();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _dialogUIController.OpenDialog(DialogIndex);
    }
}