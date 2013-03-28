using UnityEngine;
using System.Collections;

public class EarlyFlightModel : MonoBehaviour {
	
	public float speed;
	public float forceMod;
	public float turnSpeed;
	private Vector3 lastPosition;
	
	void Start () {
		forceMod = 15.0f;
		turnSpeed = 0.3f;
		lastPosition = Vector3.zero;
	}
	
	void FixedUpdate () {
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
		
		// THRUST
        if(Input.GetKey(KeyCode.Space)) // VTOL
            ApplyLinearForce(transform.up);
		if(Input.GetKey(KeyCode.UpArrow)) // FORWARD
            ApplyLinearForce(transform.forward);
		if(Input.GetKey(KeyCode.DownArrow)) // REVERSE
            ApplyLinearForce(-transform.forward);
		
		// PITCH
        if(Input.GetKey(KeyCode.W)) // PITCH DOWN
            ApplyRotationalForce(transform.right);
        if(Input.GetKey(KeyCode.S)) // PITCH UP
            ApplyRotationalForce(-transform.right);
		
		// YAW
        if(Input.GetKey(KeyCode.LeftArrow)) //YAW LEFT
            ApplyRotationalForce(-transform.up);
        if(Input.GetKey(KeyCode.RightArrow)) //YAW RIGHT
            ApplyRotationalForce(transform.up);
		
		// ROTATION
		if(Input.GetKey (KeyCode.A)) //ROTATE LEFT
			ApplyRotationalForce(transform.forward);
		if(Input.GetKey (KeyCode.D)) //ROTATE RIGHT
			ApplyRotationalForce(-transform.forward);
	}
	
	
	void ApplyLinearForce(Vector3 direction)
	{
		rigidbody.AddForce(direction * forceMod);
	}
	
	void ApplyRotationalForce(Vector3 direction)
	{
		rigidbody.AddTorque(direction * turnSpeed);
	}
}
