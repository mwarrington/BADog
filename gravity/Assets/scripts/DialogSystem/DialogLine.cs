using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLine : MonoBehaviour
{
    public string Speaker;
    public string LineText;
    public int Index;
    public int NextIndex;

    public DialogLine(int index, string speaker, string lineText, int nextLine)
    {
        Index = index;
        Speaker = speaker;
        LineText = lineText;
        NextIndex = nextLine;
    }
}