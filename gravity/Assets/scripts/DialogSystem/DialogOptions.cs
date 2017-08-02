using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOptions : MonoBehaviour
{
    public int DialogOptionsIndex,
               FollowUpLine;
    public string DO1,
                  DO2;

    public DialogOptions(int dialogOptionsIndex, int followUpLine, string do1, string do2)
    {
        DialogOptionsIndex = dialogOptionsIndex;
        FollowUpLine = followUpLine;
        DO1 = do1;
        DO2 = do2;
    }
}