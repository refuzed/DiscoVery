using UnityEngine;
using System.Collections;

public class EarlyFlightModel : MonoBehaviour {
	
	private float deadzone;
	private float lookSensitivity;
	private float speed;
	private float forceMod;
	private float turnSpeed;
	
	void Start () {
		deadzone = 0.5f;
		lookSensitivity = 5.0f;
		forceMod = 15.0f;
		turnSpeed = 0.3f;
	}
	
	void FixedUpdate () {
		CheckKeyboardInputs();
		CheckGamepadInputs();
	}
	
	void CheckKeyboardInputs()
	{
		// THRUST
        if(Input.GetKey(KeyCode.Space)) // VTOL
            ApplyLinearForce(transform.up, 1);
		if(Input.GetKey(KeyCode.UpArrow)) // FORWARD
            ApplyLinearForce(transform.forward, 1);
		if(Input.GetKey(KeyCode.DownArrow)) // REVERSE
            ApplyLinearForce(-transform.forward, 1);
		
		// PITCH
        if(Input.GetKey(KeyCode.W)) // PITCH DOWN
            ApplyRotationalForce(transform.right, 1);
        if(Input.GetKey(KeyCode.S)) // PITCH UP
            ApplyRotationalForce(-transform.right, 1);
		
		// YAW
        if(Input.GetKey(KeyCode.RightArrow)) //YAW RIGHT
            ApplyRotationalForce(transform.up, 1);
        if(Input.GetKey(KeyCode.LeftArrow))  //YAW LEFT
            ApplyRotationalForce(transform.up, -1);
		
		// ROTATION
		if(Input.GetKey (KeyCode.D)) //ROTATE RIGHT
			ApplyRotationalForce(transform.forward, -1);
		if(Input.GetKey (KeyCode.A)) //ROTATE LEFT
			ApplyRotationalForce(transform.forward, 1);
		
		// OHSHIT
		if(Input.GetKey(KeyCode.Escape))
			ResetPosition();
	}
	
	void CheckGamepadInputs()
	{
		// THRUST
        if(Input.GetAxis("LeftVertical") > deadzone) // VTOL
            ApplyLinearForce(transform.up, Input.GetAxis("LeftVertical") * 3.0f);
        if(Input.GetAxis("LeftVertical") < -deadzone) // INVERSE VTOL
            ApplyLinearForce(transform.up, Input.GetAxis("LeftVertical"));
		if(Input.GetButton("LB")) // FORWARD THRUST
            ApplyLinearForce(transform.forward, -10.0f);
        if(Input.GetButton("RB")) // REVERSE THRUST
            ApplyLinearForce(transform.forward, 3.0f);
		
		// PITCH
        if(Input.GetAxis("RightVertical") > deadzone) // PITCH DOWN
            ApplyRotationalForce(transform.right, Input.GetAxis("RightVertical") * lookSensitivity);
        if(Input.GetAxis("RightVertical") < -deadzone) // PITCH UP
            ApplyRotationalForce(transform.right, Input.GetAxis("RightVertical") * lookSensitivity);
		
		// YAW
        if(Input.GetAxis("LeftHorizontal") > deadzone) //YAW RIGHT
            ApplyRotationalForce(transform.up, Input.GetAxis("LeftHorizontal") * lookSensitivity / 3);
        if(Input.GetAxis("LeftHorizontal") < -deadzone) //YAW LEFT
            ApplyRotationalForce(transform.up, Input.GetAxis("LeftHorizontal") * lookSensitivity / 3);
		
		// ROTATION
		if(Input.GetAxis("RightHorizontal") > deadzone) //ROTATE RIGHT
			ApplyRotationalForce(transform.forward, -Input.GetAxis("RightHorizontal") * lookSensitivity);	
		if(Input.GetAxis("RightHorizontal") < -deadzone) //ROTATE LEFT
			ApplyRotationalForce(transform.forward, -Input.GetAxis("RightHorizontal") * lookSensitivity);
		
		// OHSHIT
		if(Input.GetButton ("Fire1"))
			ResetPosition();
	}
	
	void ApplyLinearForce(Vector3 direction, float extraIntensity)
	{
		rigidbody.AddForce(direction * forceMod * extraIntensity);
	}
	
	void ApplyRotationalForce(Vector3 direction, float extraIntensity)
	{
		rigidbody.AddTorque(direction * turnSpeed * extraIntensity);
	}
	
	void ResetPosition()
	{
		rigidbody.MoveRotation(new Quaternion(0,0,0,0));
		rigidbody.MovePosition(new Vector3(938, 200, 1420));
	}
}
