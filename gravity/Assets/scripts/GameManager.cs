using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager TheGameManager;
    //A static field that contains all active pausable scripts
    static List<iPausable> allPausables = new List<iPausable>();

    private void Awake()
    {
        TheGameManager = this;
    }

    //This method will pause all pausable scritps
    public void WorldPause()
    {
        foreach (iPausable ip in allPausables)
        {
            ip.TogglePause();
        }
    }

    //Pausable methods call this method to add themselves to the static field allPausables
    public void AddToPausables(iPausable pausable)
    {
        allPausables.Add(pausable);
    }

    //Pausable methods call this method to remove themselves from the static field allPausables before they delete themsevels
    public void RemoveFromPausables(iPausable pausable)
    {
        allPausables.Remove(pausable);
    }
}