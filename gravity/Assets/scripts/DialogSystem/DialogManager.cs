using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TextAsset CurrentDialogDatabase;
    public List<DialogLine> CurrentDialogLines;

    private int _currentLine;
    private bool _parsingSpeaker,
                 _parsingLine;
    
    void Start()
    {
        DialogParser();
    }
    
    void Update()
    {

    }

    private void DialogParser()
    {
        for (int i = 0; i < CurrentDialogDatabase.text.Length; i++)
        {
            if (CurrentDialogDatabase.text[i] == '(')
            {
                i++;
                if (CurrentDialogDatabase.text[i] == 'i')
                {
                    i += 2;

                    CurrentDialogLines.Add(new DialogLine(int.Parse(CurrentDialogDatabase.text[i].ToString()), "", "", -1));
                    _currentLine = int.Parse(CurrentDialogDatabase.text[i].ToString());
                    DialogLine dl = CurrentDialogLines[_currentLine];
                    i += 2;
                    continue;
                }

                if (CurrentDialogDatabase.text[i] == 's')
                {
                    _parsingSpeaker = true;
                    i++;
                    continue;
                }

                if (CurrentDialogDatabase.text[i] == 'l')
                {
                    _parsingLine = true;
                    i++;
                    continue;
                }

                if(CurrentDialogDatabase.text[i] == 'n')
                {
                    i += 2;
                    CurrentDialogLines[_currentLine].NextIndex = int.Parse(CurrentDialogDatabase.text[i].ToString());
                    i += 2;
                }
            }
            else if(_parsingSpeaker)
            {
                if (CurrentDialogDatabase.text[i] != ';')
                    CurrentDialogLines[_currentLine].Speaker += CurrentDialogDatabase.text[i];
                else
                {
                    _parsingSpeaker = false;
                }
            }
            else if(_parsingLine)
            {
                if (CurrentDialogDatabase.text[i] != ';')
                    CurrentDialogLines[_currentLine].LineText += CurrentDialogDatabase.text[i];
                else
                {
                    _parsingLine = false;
                }
            }
        }
    }
}