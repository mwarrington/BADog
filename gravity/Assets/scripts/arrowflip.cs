using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowflip : MonoBehaviour
{
    private Transform _dogpos;
    
	void Start ()
	{
	    _dogpos = GameObject.Find("playerdog").transform;
	}
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(180f, 0f, 0f);
        }

        if (transform != null && _dogpos != null)
        {
            transform.position = new Vector3(transform.position.x, _dogpos.position.y, transform.position.z);
        }
    }
}
