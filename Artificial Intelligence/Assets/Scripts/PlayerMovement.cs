using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private const float FwSpeed = 0.5f; //forward movement speed
    private const float HzSpeed = 0.3f; //horizontal movement speed
    private const float MouseSensitivity = 5f;

    private Rigidbody _rb; //the rigid body for the player

	// Use this for initialization
	void Start ()
	{
	    _rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
    void Update()
    {
        /* This script was taken and adapted from a forum post by user DroidifyDevs
         * https://forum.unity.com/threads/first-person-movement.495804/ */
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
        _rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * FwSpeed) +
                         (transform.right * Input.GetAxis("Horizontal") * HzSpeed));
    }
}
