using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DialogUIController : MonoBehaviour
{
    //Selected dialog option property
    protected bool option1Highlighted
    {
        get
        {
            //gets value of private field that stores the true value
            return _option1Highlighted;
        }

        set
        {
            //When setting this property a value that is different then it was before...
            if (_option1Highlighted != value)
            {
                //And the value is true...
                if (value)
                {
                    //Make the first dialog option appear selected
                    _dialogOption1.image.color = Color.white;
                    _dialogOption1Text.color = Color.black;

                    //Make the second dialog option appear unselected
                    _dialogOption2.image.color = Color.black;
                    _dialogOption2Text.color = Color.white;
                }
                else
                {
                    //Make the first dialog option appear unselected
                    _dialogOption1.image.color = Color.black;
                    _dialogOption1Text.color = Color.white;

                    //Make the second dialog option appear selected
                    _dialogOption2.image.color = Color.white;
                    _dialogOption2Text.color = Color.black;
                }

                //then stores the new value in the private field
                _option1Highlighted = value;
            }
        }
    }

    public float TypeSpeed = 1;

    private MEDogController _medog;
    private IEnumerator _typingCoroutine;
    private DialogManager _dialogManager;
    private GameObject _dialogBoxObject,
                       _dialogOptionsObject;
    private DialogLine _currentDialogLine;
    private DialogOptions _curretDialogOptions;

    //Private fields for the dialog UI components
    private Button _dialogOption1,
                   _dialogOption2;
    private Image _textBoxImage;
    private Text _textBoxText,
                 _dialogOption1Text,
                 _dialogOption2Text;

    private Vector3 _textBoxToNPCPos;
    private bool _inDialog,
                 _inDialogBox,
                 _inDialogOptions,
                 _option1Highlighted,
                 _isTyping,
                 _restartGame;

    void Start()
    {
        _dialogManager = FindObjectOfType<DialogManager>();
        _medog = FindObjectOfType<MEDogController>();

        //Setting the value of dialog UI components
        _textBoxImage = GameObject.Find("DialogToNPCPoint/DialogBox").GetComponent<Image>();
        _textBoxText = GameObject.Find("DialogToNPCPoint/DialogBox/DialogText").GetComponent<Text>();
        _textBoxToNPCPos = GameObject.Find("DialogToNPCPoint").transform.position;

        _dialogOption1 = GameObject.Find("DialogOption1").GetComponent<Button>();
        _dialogOption2 = GameObject.Find("DialogOption2").GetComponent<Button>();
        _dialogOption1Text = _dialogOption1.GetComponentInChildren<Text>();
        _dialogOption2Text = _dialogOption2.GetComponentInChildren<Text>();

        //Setting dialog objects and setting them to be inactive until dialog is needed
        _dialogBoxObject = GameObject.Find("DialogBox");
        _dialogOptionsObject = GameObject.Find("DialogOptions");
        _dialogBoxObject.SetActive(false);
        _dialogOptionsObject.SetActive(false);
    }

    //Call this method which takes an int that represents the desired dialog line index at which to begin/continue the dialog.
    public void OpenDialog(int index, bool restartGameAtEnd)
    {
        if (!_inDialog)
        {
            _restartGame = restartGameAtEnd;
            _inDialog = true;
            GameManager.TheGameManager.WorldPause();
        }

        _currentDialogLine = _dialogManager.CurrentDialogLines[index];
        _dialogBoxObject.SetActive(true);
        _dialogOptionsObject.SetActive(false);
        _inDialogBox = true;
        _inDialogOptions = false;

        _isTyping = true;
        _textBoxText.text = "";
        _typingCoroutine = TypeText();
        StartCoroutine(_typingCoroutine);
    }

    //Call this method which takes an int that represents the desired dialog options index to display
    private void OpenDialogOptions(int index)
    {
        _curretDialogOptions = _dialogManager.CurrentDialogOptionsList[index];
        _dialogOptionsObject.SetActive(true);
        _dialogBoxObject.SetActive(false);
        _inDialogOptions = true;
        option1Highlighted = true;
        _inDialogBox = false;

        _dialogOption1Text.text = _curretDialogOptions.DO1;
        _dialogOption2Text.text = _curretDialogOptions.DO2;
    }

    private void Update()
    {
        if (_inDialog)
            InputHandler();
    }

    //This method contains all code related to player inputs for the dialog ui components
    private void InputHandler()
    {
        if (_inDialogBox) //This bit handles player inputs while in a dialog box
        {
            //First checks to see if you're typing if so we end the type coroutine and fill in the text box.
            if (_isTyping && Input.GetKeyDown(KeyCode.Space))
            {
                StopCoroutine(_typingCoroutine);
                _textBoxText.text = "";
                _textBoxText.text = _currentDialogLine.LineText;
                _isTyping = false;
            }
            else if (Input.GetKeyDown(KeyCode.Space))//If the player presses space we will either proceed to the designated next dialog options or end the dialog
            {
                if (_currentDialogLine.NextDialogLine == -1)
                {
                    if (_currentDialogLine.NextDialogOptionsIndex != -1)
                        OpenDialogOptions(_currentDialogLine.NextDialogOptionsIndex);
                    else
                    {
                        EndDialog();
                    }
                }
                else
                {
                    OpenDialog(_currentDialogLine.NextDialogLine, false);
                }
            }
        }
        else if (_inDialogOptions) //This bit handles player inputs while in dialog options
        {
            //Pressing either left or right will swap which dialog option is set to be selected
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                option1Highlighted = !option1Highlighted;
            }

            //If the player presses space we will either proceed to the designated next dialog line or end the dialog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (option1Highlighted)
                {
                    if (_curretDialogOptions.FollowUpLine1 != -1)
                    {
                        OpenDialog(_curretDialogOptions.FollowUpLine1, false);
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
                        OpenDialog(_curretDialogOptions.FollowUpLine2, false);
                    }
                    else
                    {
                        EndDialog();
                    }
                }
            }
        }
    }

    //Call this method to end dialog. It sets both dialog ui objects to be inactive and unpauses the game
    private void EndDialog()
    {
        _inDialog = false;
        GameManager.TheGameManager.WorldPause();
        _dialogBoxObject.SetActive(false);
        _dialogOptionsObject.SetActive(false);

        if (_restartGame)
            SceneManager.LoadScene("Start");
    }

    IEnumerator TypeText()
    {
        for (int i = 0; i < _currentDialogLine.LineText.Length; i++) //char c in _currentConvo.MyLines[_currentLineIndex].LineText.ToCharArray())
        {
            _textBoxText.text += _currentDialogLine.LineText[i];

            yield return new WaitForSeconds(TypeSpeed);
        }

        _isTyping = false;
    }
}