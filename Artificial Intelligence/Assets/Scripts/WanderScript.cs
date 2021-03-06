﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script is used for NPC actors in the scene to make
 * them wander aimlessly throughout the scene */
public class WanderScript : MonoBehaviour {

    /* Time constants */
    private const float MinWanderDuration = 1f;  //min amount of time the actor can move before waiting
    private const float MaxWanderDuration = 5f;  //max amount of time the actor can move before waiting
    private const float MinWaitDuration = .5f;   //min amount of time the actor can wait before walking
    private const float MaxWaitDuration = 3f;    //max amount of time the actor can wait before walking
    
    /* time variables */
    private float _wanderDuration;          //actual amount of time spent wandering
    private float _elapsedWander;           //amount of time elapsed since the walk began, init to 0
    private float _waitDuration;            //actual amount of time spent waiting
    private float _elapsedWait;             //amount of time elapsed whlie waiting

    /* Direction and speed variables */
    private float _randX;
    private float _randZ;
    private float _speed;
    private Vector3 _direction;

    private bool _isMoving = false;         //true if moving, false otherwise

	// Use this for initialization
	void Start ()
	{
        /* initialize our directions to random values */
	    _randX = Random.Range(-1f, 1f);
	    _randZ = Random.Range(-1f, 1f);
        /* initialize our durations */
	    _wanderDuration = Random.Range(MinWanderDuration, MaxWanderDuration);
	    _waitDuration = Random.Range(MinWaitDuration, MaxWaitDuration);
        /* initialize elapsed wait to wait so the actors start wandering */
	    _elapsedWait = _waitDuration;

	}
	
	// Update is called once per frame
	void Update ()
	{
        /* if the actor is not moving and our wait time has reached
         * the maximum then start the process of moving in a random direction */
	    if (!_isMoving && _elapsedWait >= _waitDuration)
	    {
	        _wanderDuration = Random.Range(MinWanderDuration, MaxWanderDuration);
            _direction = new Vector3(_randX, 0f, _randZ).normalized;
	        _speed = .025f;
            _elapsedWait = 0;
	        _isMoving = true;
	        StopAllCoroutines();
	        StartCoroutine(ElapseTime(_isMoving));
        }
        /* otherwise if the actor is moving and their walk time has reached
         * its maximum, start the waiting process and halt their movement
         * additionally, reset the random direction */
	    else if (_isMoving && _elapsedWander >= _wanderDuration)
	    {
	        _waitDuration = Random.Range(MinWaitDuration, MaxWaitDuration);
            _direction = Vector3.zero;
	        _speed = 0;
	        _elapsedWander = 0;
	        _isMoving = false;
	        _randX = Random.Range(-1f, 1f);
	        _randZ = Random.Range(-1f, 1f);
            StopAllCoroutines();
	        StartCoroutine(ElapseTime(_isMoving));
        }
        transform.Translate(_direction * _speed);
	}

    IEnumerator ElapseTime(bool which)
    {
        /* depending on which Time we're elapsing, iterate
         * one of the time counters */
        if (which)
        {
            while (_elapsedWander < _wanderDuration)
            {
                _elapsedWander += 1;
                yield return new WaitForSeconds(1f);
            }
        }
        else
        {
            while (_elapsedWait < _waitDuration)
            {
                _elapsedWait += 1;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
