using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEDogController : MonoBehaviour
{
    protected bool visible
    {
        get
        {
            return _visible;
        }

        set
        {
            if(_visible != value)
            {
                if (value)
                {

                }
                else
                {

                }

                _visible = value;
            }
        }
    }
    private bool _visible;

    private DialogUIController _dialogUIController;

    void Start()
    {
        _dialogUIController = FindObjectOfType<DialogUIController>();
    }
    
    void Update()
    {

    }

    public void ObstacleHit(int obstIndex)
    {
        visible = true;
        _dialogUIController.OpenDialog(obstIndex);
    }

    public void HideMeDog()
    {
        visible = false;
    }
}