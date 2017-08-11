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
                _myRenderer.enabled = value;

                //if (value)
                //{
                //    _myRenderer.enabled = true;
                //}
                //else
                //{
                //    _myRenderer.enabled = false;
                //}

                _visible = value;
            }
        }
    }
    private bool _visible;

    private DialogUIController _dialogUIController;
    private SpriteRenderer _myRenderer;

    void Start()
    {
        _dialogUIController = FindObjectOfType<DialogUIController>();
        _myRenderer = this.GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {

    }

    public void ObstacleHit(int obstIndex)
    {
        visible = true;
        _dialogUIController.OpenDialog(obstIndex, true);
    }

    public void HideMeDog()
    {
        visible = false;
    }
}