using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playergravity : MonoBehaviour
{
    private AudioSource _bark;

    // Use this for initialization
    void Start () {
        _bark = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        Physics2D.gravity *= -1;
            _bark.Play();
        }

    }
}
