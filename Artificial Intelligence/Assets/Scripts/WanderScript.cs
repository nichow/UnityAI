using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script is used for NPC actors in the scene to make
 * them wander aimlessly throughout the scene */
public class WanderScript : MonoBehaviour {

    /* Time variables */
    private float _maxWanderDuration = 10f; //max amount of time the actor can move before waiting
    private float _elapsedWalk = 0f;        //amount of time elapsed since the walk began
    private float _maxWaitTime = 3f;        //max amount of time the actor can wait before walking again
    private float _elapsedWait;             //amount of time elapsed whlie waiting
    /* Direction variables */
    private float _randX;
    private float _randZ;

    private bool _isMoving = false;         //true if moving, false otherwise
	// Use this for initialization
	void Start ()
	{
        /* initialize our directions to random values */
	    _randX = Random.Range(-1f, 1f);
	    _randZ = Random.Range(-1f, 1f);
        /* initialize elapsed wait to max wait so the actors start wandering */
	    _elapsedWait = _maxWaitTime;

	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!_isMoving && _elapsedWait >= _maxWaitTime)
	    {
	        var direction = new Vector3(_randX, 0f, _randZ).normalized;
	        _elapsedWait = 0;
	        _isMoving = true;
	    }
	}
}
