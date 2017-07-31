using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playergravity : MonoBehaviour
{
    public AudioSource bark;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        Physics2D.gravity *= -1;
            bark.Play();
        }

    }
}
