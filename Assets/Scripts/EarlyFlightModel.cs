using UnityEngine;
using System.Collections;

public class EarlyFlightModel : MonoBehaviour {
	
	private float deadzone;
	private float lookSensitivity;
	private float speed;
	private float forceMod;
	private float turnSpeed;
	private bool cameraSwap;
	
	void Start () {
		deadzone = 0.5f;
		lookSensitivity = 5.0f;
		forceMod = 15.0f;
		turnSpeed = 0.3f;
		cameraSwap = false;
	}
	
	void FixedUpdate () {
		CheckKeyboardInputs();
		CheckGamepadInputs();
	}
	
	void CheckKeyboardInputs()
	{
		// THRUST
        if(Input.GetKey(KeyCode.W)) // VTOL
            ApplyLinearForce(transform.up, 2);
        if(Input.GetKey(KeyCode.S)) // INVERSE VTOL
            ApplyLinearForce(transform.up, -2);
		if(Input.GetKey(KeyCode.E)) // FORWARD
            ApplyLinearForce(transform.forward, 2);
		if(Input.GetKey(KeyCode.Q)) // REVERSE
            ApplyLinearForce(-transform.forward, 2);
		
		// PITCH
        if(Input.GetKey(KeyCode.UpArrow)) // PITCH DOWN
            ApplyRotationalForce(transform.right, lookSensitivity * .75f);
        if(Input.GetKey(KeyCode.DownArrow)) // PITCH UP
            ApplyRotationalForce(-transform.right, lookSensitivity * .75f);
		
		// YAW
        if(Input.GetKey(KeyCode.D)) //YAW RIGHT
            ApplyRotationalForce(transform.up, lookSensitivity * .75f);
        if(Input.GetKey(KeyCode.A))  //YAW LEFT
            ApplyRotationalForce(transform.up, -lookSensitivity * .75f);
		
		// ROTATION
		if(Input.GetKey (KeyCode.RightArrow)) //ROTATE RIGHT
			ApplyRotationalForce(transform.forward, -lookSensitivity * .75f);
		if(Input.GetKey (KeyCode.LeftArrow)) //ROTATE LEFT
			ApplyRotationalForce(transform.forward, lookSensitivity * .75f);
		
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
		if(Input.GetButton("RB")) // FORWARD THRUST
            ApplyLinearForce(transform.forward, 3.0f);
        if(Input.GetButton("LB")) // REVERSE THRUST
            ApplyLinearForce(transform.forward, -3.0f);
		
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
		rigidbody.MovePosition(new Vector3(938, 600, 1420));
	}
}
