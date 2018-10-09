using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private const float FwSpeed = 0.1f; //forward movement speed
    private const float BwSpeed = 0.05f; //backward movement speed
    private const float HzSpeed = 0.075f; //horizontal movement speed

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
	    if (Input.GetAxis("Vertical") > 0)
	    {
            transform.Translate(Vector3.forward * FwSpeed);
	    }

	    if (Input.GetAxis("Vertical") < 0)
	    {
            transform.Translate(Vector3.back * BwSpeed);
	    }

	    if (Input.GetAxis("Horizontal") > 0)
	    {
            transform.Translate(Vector3.right * HzSpeed);
	    }

	    if (Input.GetAxis("Horizontal") < 0)
	    {
            transform.Translate(Vector3.left * HzSpeed);
	    }
	}
}
