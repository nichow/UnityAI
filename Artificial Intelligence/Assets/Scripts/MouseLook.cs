using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* The foundation of this script was taken from user IJM on the Unity3D forums
 * Any alterations were done for the purposes of this project by myself
 * Link to the original script can be found here:
 * https://answers.unity.com/questions/29741/mouse-look-script.html */

public class MouseLook : MonoBehaviour
{
    private enum RotationAxes
    {
        MouseXandY = 0, MouseX = 1, MouseY = 2
    }
    private RotationAxes _axes = RotationAxes.MouseXandY;

    /* sensitivity for hz and vert axes respectively */
    private const float SensX = 15f;
    private const float SensY = 15f;

    /* min and max rotation for y axis meant to stop from
     * being able to turn all the way around vertically */
    private const float MinY = -60f;
    private const float MaxY =  60f;

    /* variables for rotation state */
    private float _rotationX = 0f;
    private float _rotationY = 0f;

    private Quaternion _originalRoation;

    // Use this for initialization
    void Start ()
    {
        var rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.freezeRotation = true;
        }

        _originalRoation = transform.localRotation;
    }
	
	// Update is called once per frame
	void Update () {
        /* switch for the two axes of movement and the combination */
	    switch (_axes)
	    {
	        case RotationAxes.MouseXandY:
	        {
	            _rotationX += Input.GetAxis("Mouse X") * SensX;
	            _rotationY += Input.GetAxis("Mouse Y") * SensY;
	            _rotationY = ClampAngle(_rotationY, MinY, MaxY);
	            var xQuaternion = Quaternion.AngleAxis(_rotationX, Vector3.up);
	            var yQuaternion = Quaternion.AngleAxis(_rotationY, -Vector3.right);
	            transform.localRotation = _originalRoation * xQuaternion * yQuaternion;
	            break;
	        }
	        case RotationAxes.MouseX:
	        {
	            _rotationX += Input.GetAxis("Mouse X") * SensX;
	            var xQuaternion = Quaternion.AngleAxis(_rotationX, Vector3.up);
	            transform.localRotation = _originalRoation * xQuaternion;
	            break;
	        }
	        case RotationAxes.MouseY:
	        {
	            _rotationX += Input.GetAxis("Mouse Y") * SensY;
	            var yQuaternion = Quaternion.AngleAxis(_rotationX, -Vector3.right);
	            transform.localRotation = _originalRoation * yQuaternion;
	            break;
	        }
	    }
	}

    /* method clamps angle to being within a certain range determined by min and max */
    private static float ClampAngle(float angle, float min, float max)
    {
        angle %= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}
