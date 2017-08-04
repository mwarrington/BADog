using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the class for dialog lines
public class DialogLine
{
    public string Speaker;
    public string LineText;
    public int Index;
    public int NextDialogOptionsIndex;
    public int NextDialogLine = -1;

    //A standard contructor, sets values of dialog lines when they are created/this called
    public DialogLine(int index, string speaker, string lineText, int nextDialogOptionsIndex)
    {
        Index = index;
        Speaker = speaker;
        LineText = lineText;
        NextDialogOptionsIndex = nextDialogOptionsIndex;
    }
}