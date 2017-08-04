using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the class for a set of dialog options
public class DialogOptions
{
    public int DialogOptionsIndex,
               FollowUpLine1,
               FollowUpLine2;
    public string DO1,
                  DO2;

    //Standard constructor, sets values of the dialog options when creating/calling this method
    public DialogOptions(int dialogOptionsIndex, int followUpLine1, int followUpLine2, string do1, string do2)
    {
        DialogOptionsIndex = dialogOptionsIndex;
        FollowUpLine1 = followUpLine1;
        FollowUpLine2 = followUpLine2;
        DO1 = do1;
        DO2 = do2;
    }
}