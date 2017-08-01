using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public int Index = 0;
    public string[] Levels = new string[] {"Second", "SkyEnd", "GroundEnd", "CarEnd"};

    public void Newgame(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Index < Levels.Length - 1)
            {
                ++Index;
                transform.Translate(Vector3.down * 1.2f, Space.World);
            }
            else
            {
                Index = 0;
                transform.position = new Vector3(-.2f, 1.8f, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Index > 0)
            {
                --Index;
                transform.Translate(Vector3.up * 1.2f, Space.World);
            }
            else
            {
                Index = Levels.Length - 1;
                transform.position = new Vector3(-.2f, -1.8f, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            Newgame(Levels[Index]);
        }


    }

}
