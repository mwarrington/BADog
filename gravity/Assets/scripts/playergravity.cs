using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playergravity : MonoBehaviour, iPausable
{
    private GameManager _theGameManager;
    private Rigidbody2D _myRigidbody;
    private AudioSource _bark;
    private float _lastGravityValue,
                  _lastVelocity;
    private bool _paused;

    public void TogglePause()
    {
        _paused = !_paused;
        if (_paused)
        {
            _lastGravityValue = Physics2D.gravity.y;
            _lastVelocity = _myRigidbody.velocity.y;
            Physics2D.gravity = Vector2.zero;
            _myRigidbody.velocity = Vector2.zero;
        }
        else
        {
            Physics2D.gravity = new Vector2(0, _lastGravityValue);
            _myRigidbody.velocity = new Vector2(0, _lastVelocity);
        }
    }

    // Use this for initialization
    void Start () {
        _myRigidbody = this.GetComponent<Rigidbody2D>();
        _bark = GetComponent<AudioSource>();
        _theGameManager = GameManager.TheGameManager;
        _theGameManager.AddToPausables(this);
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.Space) && !_paused)
	    {
	        Physics2D.gravity *= -1;
            _bark.Play();
        }

    }
}
