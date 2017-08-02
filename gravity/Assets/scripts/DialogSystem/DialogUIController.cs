using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogUIController : MonoBehaviour
{
    private Image _textBoxImage;
    private Text _textBoxText;
    private Vector3 _textBoxToNPCPos;

    void Start()
    {
        _textBoxImage = GameObject.Find("DialogToNPCPoint/DialogBox").GetComponent<Image>();
        _textBoxText = GameObject.Find("DialogToNPCPoint/DialogBox/DialogText").GetComponent<Text>();
        _textBoxToNPCPos = GameObject.Find("DialogToNPCPoint").transform.position;
    }
}