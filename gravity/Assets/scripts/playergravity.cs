using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playergravity : MonoBehaviour, iPausable
{
    public Transform GroundChecker;
    private Animator _myAnimator;
    private GameManager _theGameManager;
    private Rigidbody2D _myRigidbody;
    private AudioSource _bark;
    private float _lastGravityValue,
                  _lastVelocity;
    private bool _paused;

    public void TogglePause()
    {
        _paused = !_paused;

        _myAnimator.SetBool("Pause", _paused);

        if (_paused)
        {
            if(!_myRigidbody)
                _myRigidbody = this.GetComponent<Rigidbody2D>();

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

    private void Awake()
    {
        _myRigidbody = this.GetComponent<Rigidbody2D>();
        _myAnimator = GetComponentInChildren<Animator>();
    }

    void Start () {
        _bark = GetComponent<AudioSource>();
        _theGameManager = GameManager.TheGameManager;
        _theGameManager.AddToPausables(this);
	}
	
	void Update () {

	    if (Input.GetKeyDown(KeyCode.Space) && !_paused)
	    {
	        _myRigidbody.gravityScale *= -1;
            _bark.Play();
        }

        _myAnimator.SetBool("Grounded", Physics2D.OverlapCircle(GroundChecker.position, 0.3f));

    }
}
