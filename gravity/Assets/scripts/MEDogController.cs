using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEDogController : MonoBehaviour
{
    public GameObject MyModelObject;

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
                MyModelObject.SetActive(value);

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
    private bool _visible = true;

    private DialogUIController _dialogUIController;
    private Animator _myAnimator;

    void Start()
    {
        _dialogUIController = FindObjectOfType<DialogUIController>();
        _myAnimator = this.GetComponentInChildren<Animator>();
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

    public void Bark()
    {
        _myAnimator.SetBool("Bark", true);
        Invoke("FinishBark", 0.1f);
    }

    private void FinishBark()
    {
        _myAnimator.SetBool("Bark", false);
    }
}