using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TextAsset CurrentDialogDatabase;
    public List<DialogLine> CurrentDialogLines;
    public List<DialogOptions> CurrentDialogOptionsList;

    private int _currentLine,
                _currentDO;
    private bool _parsingSpeaker,
                 _parsingLine,
                 _parsingDO1,
                 _parsingDO2;
    
    void Start()
    {
        DialogParser();
    }
    
    void Update()
    {

    }

    //This method parses data from .txt files into dialog lines and dialog options
    private void DialogParser()
    {
        for (int i = 0; i < CurrentDialogDatabase.text.Length; i++)
        {
            //If the current char of the dialog database text is '(' then we know it will be imediately followed by a character that indicates what kind of data we'll be reading
            if (CurrentDialogDatabase.text[i] == '(')
            {
                i++;
                //i denotes dialog line index
                if (CurrentDialogDatabase.text[i] == 'i')
                {
                    i += 2;

                    _currentLine = int.Parse(CurrentDialogDatabase.text[i].ToString());
                    CurrentDialogLines.Add(new DialogLine(_currentLine, "", "", -1));
                    i += 2;
                    continue;
                }

                //d denotes dialog options index
                if (CurrentDialogDatabase.text[i] == 'd')
                {
                    i += 2;

                    _currentDO = int.Parse(CurrentDialogDatabase.text[i].ToString());
                    CurrentDialogOptionsList.Add(new DialogOptions(_currentDO, -1, -1, "", ""));
                    i += 2;
                    continue;
                }

                //s denotes dialog line speaker
                if (CurrentDialogDatabase.text[i] == 's')
                {
                    _parsingSpeaker = true;
                    i++;
                    continue;
                }

                //l denotes dialog line line
                if (CurrentDialogDatabase.text[i] == 'l')
                {
                    _parsingLine = true;
                    i++;
                    continue;
                }

                //n denotes dialog line next dialog options (which dialog options to switch to when proceeding)
                if(CurrentDialogDatabase.text[i] == 'n')
                {
                    i += 2;

                    //if this value is set to '!' the next dialog options value will be set at -1 which means this dialog line ends the dialog
                    if (CurrentDialogDatabase.text[i] != '!')
                        CurrentDialogLines[_currentLine].NextDialogOptionsIndex = int.Parse(CurrentDialogDatabase.text[i].ToString());
                    else
                        CurrentDialogLines[_currentLine].NextDialogOptionsIndex = -1;

                    i += 2;
                    continue;
                }
                
                //1 denotes dialog options option 1 text
                if (CurrentDialogDatabase.text[i] == '1')
                {
                    _parsingDO1 = true;
                    i++;
                    continue;
                }
                //2 denotes dialog options option 2 text
                if (CurrentDialogDatabase.text[i] == '2')
                {
                    _parsingDO2 = true;
                    i++;
                    continue;
                }

                //o denotes dialog options option one next dialog line (which dialog line to switch to when proceeding)
                if (CurrentDialogDatabase.text[i] == 'o')
                {
                    i += 2;

                    //if this value is set to '!' the next dialog line value will be set at -1 which means this dialog option ends the dialog
                    if (CurrentDialogDatabase.text[i] != '!')
                        CurrentDialogOptionsList[_currentDO].FollowUpLine1 = int.Parse(CurrentDialogDatabase.text[i].ToString());
                    else
                        CurrentDialogOptionsList[_currentDO].FollowUpLine1 = -1;

                    i += 2;
                    continue;
                }

                //t denotes dialog options option two next dialog line (which dialog line to switch to when proceeding)
                if (CurrentDialogDatabase.text[i] == 't')
                {
                    i += 2;

                    //if this value is set to '!' the next dialog line value will be set at -1 which means this dialog option ends the dialog
                    if (CurrentDialogDatabase.text[i] != '!')
                        CurrentDialogOptionsList[_currentDO].FollowUpLine2 = int.Parse(CurrentDialogDatabase.text[i].ToString());
                    else
                        CurrentDialogOptionsList[_currentDO].FollowUpLine2 = -1;

                    i += 2;
                    continue;
                }
            }
            else if(_parsingSpeaker) //This section copies text into a dialog line speaker field
            {
                if (CurrentDialogDatabase.text[i] != ';') //it stops when it comes to the char ';'
                    CurrentDialogLines[_currentLine].Speaker += CurrentDialogDatabase.text[i];
                else
                    _parsingSpeaker = false;
            }
            else if(_parsingLine) //This section copies text into a dialog line line field
            {
                if (CurrentDialogDatabase.text[i] != ';') //it stops when it comes to the char ';'
                    CurrentDialogLines[_currentLine].LineText += CurrentDialogDatabase.text[i];
                else
                    _parsingLine = false;
            }
            else if(_parsingDO1) //This section copies text into a dialog options option 1 text field
            {
                if (CurrentDialogDatabase.text[i] != ';') //it stops when it comes to the char ';'
                    CurrentDialogOptionsList[_currentDO].DO1 += CurrentDialogDatabase.text[i];
                else
                    _parsingDO1 = false;
            }
            else if (_parsingDO2) //This section copies text into a dialog options option 2 text ield
            {
                if (CurrentDialogDatabase.text[i] != ';') //it stops when it comes to the char ';'
                    CurrentDialogOptionsList[_currentDO].DO2 += CurrentDialogDatabase.text[i];
                else
                    _parsingDO2 = false;
            }
        }
    }
}