using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A very simple one method interface that we use to pause various scripts
public interface iPausable
{
    //All scripts that inherit iPausable have an override for this method that pauses them in their own specific way
    //Check each iPausable script to see how they each use TogglePause()
    void TogglePause();
}