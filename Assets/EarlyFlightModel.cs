using UnityEngine;
using System.Collections;

public class EarlyFlightModel : MonoBehaviour {
	
	public float deadzone;
	public float lookSensitivity;
	public float speed;
	public float forceMod;
	public float turnSpeed;
	
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
	}
	
	void CheckGamepadInputs()
	{
		// THRUST
        if(Input.GetAxis("LeftVertical") > deadzone) // VTOL
            ApplyLinearForce(transform.up, Input.GetAxis("LeftVertical") * 2.0f);
        if(Input.GetAxis("LeftVertical") < -deadzone) // INVERSE VTOL
            ApplyLinearForce(transform.up, Input.GetAxis("LeftVertical"));
		if(Input.GetButton("LB")) // FORWARD THRUST
            ApplyLinearForce(transform.forward, -1);
        if(Input.GetButton("RB")) // REVERSE THRUST
            ApplyLinearForce(transform.forward, 1);
		
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
}
