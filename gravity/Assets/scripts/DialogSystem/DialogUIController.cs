using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogUIController : MonoBehaviour
{
    private Image _textBoxImage;
    private Text _textBoxText;

    void Start()
    {
        _textBoxImage = GameObject.Find("DialogCanvas/DialogBox").GetComponent<Image>();
        _textBoxText = GameObject.Find("DialogCanvas/DialogBox/DialogText").GetComponent<Text>();
    }
}