using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager TheGameManager;
    static List<iPausable> allPausables = new List<iPausable>();
    public List<iPausable> AllPausables
    {
        get
        {
            return allPausables;
        }
    }

    private void Awake()
    {
        TheGameManager = this;
    }

    public void AddToPausables(iPausable pausable)
    {
        allPausables.Add(pausable);
    }

    public void RemoveFromPausables(iPausable pausable)
    {
        allPausables.Remove(pausable);
    }
}