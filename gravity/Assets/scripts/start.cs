using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {

    private AudioSource _bark;

    // Use this for initialization
    void Start () {
        _bark = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        SceneManager.LoadScene("Second");
            _bark.Play();
        }
    }
}
