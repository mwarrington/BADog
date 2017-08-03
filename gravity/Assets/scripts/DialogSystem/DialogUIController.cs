using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogUIController : MonoBehaviour
{
    protected bool option1Highlighted
    {
        get
        {
            return _option1Highlighted;
        }

        set
        {
            if (_option1Highlighted != value)
            {
                if(value)
                {
                    _dialogOption1.image.color = Color.white;
                    _dialogOption1Text.color = Color.black;

                    _dialogOption2.image.color = Color.black;
                    _dialogOption2Text.color = Color.white;
                }
                else
                {
                    _dialogOption1.image.color = Color.black;
                    _dialogOption1Text.color = Color.white;

                    _dialogOption2.image.color = Color.white;
                    _dialogOption2Text.color = Color.black;
                }

                _option1Highlighted = value;
            }
        }
    }

    private DialogManager _dialogManager;
    private GameObject _dialogBoxObject,
                       _dialogOptionsObject;
    private DialogLine _currentDialogLine;
    private DialogOptions _curretDialogOptions;
    
    private Button _dialogOption1,
                   _dialogOption2;
    private Image _textBoxImage;
    private Text _textBoxText,
                 _dialogOption1Text,
                 _dialogOption2Text;
    private Vector3 _textBoxToNPCPos;
    private bool _inDialogBox,
                 _inDialogOptions,
                 _option1Highlighted;

    void Start()
    {
        _dialogManager = FindObjectOfType<DialogManager>();
        _textBoxImage = GameObject.Find("DialogToNPCPoint/DialogBox").GetComponent<Image>();
        _textBoxText = GameObject.Find("DialogToNPCPoint/DialogBox/DialogText").GetComponent<Text>();
        _textBoxToNPCPos = GameObject.Find("DialogToNPCPoint").transform.position;

        _dialogOption1 = GameObject.Find("DialogOption1").GetComponent<Button>();
        _dialogOption2 = GameObject.Find("DialogOption2").GetComponent<Button>();
        _dialogOption1Text = _dialogOption1.GetComponentInChildren<Text>();
        _dialogOption2Text = _dialogOption2.GetComponentInChildren<Text>();

        _dialogBoxObject = GameObject.Find("DialogBox");
        _dialogOptionsObject = GameObject.Find("DialogOptions");
        _dialogBoxObject.SetActive(false);
        _dialogOptionsObject.SetActive(false);
    }

    public void OpenDialog(int index)
    {
        //Pause
        _currentDialogLine = _dialogManager.CurrentDialogLines[index];
        _dialogBoxObject.SetActive(true);
        _inDialogBox = true;

        _textBoxText.text = _currentDialogLine.LineText;
    }

    private void OpenDialogOptions(int index)
    {
        _curretDialogOptions = _dialogManager.CurrentDialogOptionsList[index];
        _dialogOptionsObject.SetActive(true);
        _inDialogOptions = true;
        option1Highlighted = true;

        _dialogOption1Text.text = _curretDialogOptions.DO1;
        _dialogOption2Text.text = _curretDialogOptions.DO2;
    }

    private void Update()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        if (_inDialogBox)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_currentDialogLine.NextDialogOptionsIndex != -1)
                    OpenDialogOptions(_currentDialogLine.NextDialogOptionsIndex);
                else
                {
                    EndDialog();
                }
            }
        }

        if (_inDialogOptions)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                option1Highlighted = !option1Highlighted;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (option1Highlighted)
                {
                    if (_curretDialogOptions.FollowUpLine1 != -1)
                    {
                        OpenDialog(_curretDialogOptions.FollowUpLine1);
                    }
                    else
                    {
                        EndDialog();
                    }
                }
                else
                {
                    if (_curretDialogOptions.FollowUpLine2 != -1)
                    {
                        OpenDialog(_curretDialogOptions.FollowUpLine2);
                    }
                    else
                    {
                        EndDialog();
                    }
                }
            }
        }
    }

    private void EndDialog()
    {
        //UnPause
        _dialogBoxObject.SetActive(false);
        _dialogOptionsObject.SetActive(false);
    }
}