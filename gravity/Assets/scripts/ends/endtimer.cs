using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endtimer : MonoBehaviour {

    private float _timer = 0f;

    // Use this for initialization
    void Start()
    {
        Physics.gravity = new Vector3(0, -1);
    }

    // Update is called once per frame
	void Update () {
	    _timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && _timer > 2f)
	    {
	        SceneManager.LoadScene("Second");
	    }
    }
}