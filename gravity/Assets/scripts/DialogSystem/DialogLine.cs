using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLine : MonoBehaviour
{
    public string Speaker;
    public string LineText;
    public int Index;
    public int NextDialogOptionsIndex;

    public DialogLine(int index, string speaker, string lineText, int nextDialogOptionsIndex)
    {
        Index = index;
        Speaker = speaker;
        LineText = lineText;
        NextDialogOptionsIndex = nextDialogOptionsIndex;
    }
}