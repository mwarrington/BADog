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

                    _currentLine = int.Parse(CurrentDialogDatabase.text[i].ToString());
                    CurrentDialogLines.Add(new DialogLine(_currentLine, "", "", -1));
                    i += 2;
                    continue;
                }

                if (CurrentDialogDatabase.text[i] == 'd')
                {
                    i += 2;

                    _currentDO = int.Parse(CurrentDialogDatabase.text[i].ToString());
                    CurrentDialogOptionsList.Add(new DialogOptions(_currentDO, -1, -1, "", ""));
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

                    if (CurrentDialogDatabase.text[i] != '!')
                        CurrentDialogLines[_currentLine].NextDialogOptionsIndex = int.Parse(CurrentDialogDatabase.text[i].ToString());
                    else
                        CurrentDialogLines[_currentLine].NextDialogOptionsIndex = -1;

                    i += 2;
                    continue;
                }
                
                if (CurrentDialogDatabase.text[i] == '1')
                {
                    _parsingDO1 = true;
                    i++;
                    continue;
                } 
                if (CurrentDialogDatabase.text[i] == '2')
                {
                    _parsingDO2 = true;
                    i++;
                    continue;
                }

                if (CurrentDialogDatabase.text[i] == 'o')
                {
                    i += 2;

                    if (CurrentDialogDatabase.text[i] != '!')
                        CurrentDialogOptionsList[_currentDO].FollowUpLine1 = int.Parse(CurrentDialogDatabase.text[i].ToString());
                    else
                        CurrentDialogOptionsList[_currentDO].FollowUpLine1 = -1;

                    i += 2;
                    continue;
                }

                if (CurrentDialogDatabase.text[i] == 't')
                {
                    i += 2;

                    if (CurrentDialogDatabase.text[i] != '!')
                        CurrentDialogOptionsList[_currentDO].FollowUpLine2 = int.Parse(CurrentDialogDatabase.text[i].ToString());
                    else
                        CurrentDialogOptionsList[_currentDO].FollowUpLine2 = -1;

                    i += 2;
                    continue;
                }
            }
            else if(_parsingSpeaker)
            {
                if (CurrentDialogDatabase.text[i] != ';')
                    CurrentDialogLines[_currentLine].Speaker += CurrentDialogDatabase.text[i];
                else
                    _parsingSpeaker = false;
            }
            else if(_parsingLine)
            {
                if (CurrentDialogDatabase.text[i] != ';')
                    CurrentDialogLines[_currentLine].LineText += CurrentDialogDatabase.text[i];
                else
                    _parsingLine = false;
            }
            else if(_parsingDO1)
            {
                if (CurrentDialogDatabase.text[i] != ';')
                    CurrentDialogOptionsList[_currentDO].DO1 += CurrentDialogDatabase.text[i];
                else
                    _parsingDO1 = false;
            }
            else if (_parsingDO2)
            {
                if (CurrentDialogDatabase.text[i] != ';')
                    CurrentDialogOptionsList[_currentDO].DO2 += CurrentDialogDatabase.text[i];
                else
                    _parsingDO2 = false;
            }
        }
    }
}