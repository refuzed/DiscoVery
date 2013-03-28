using UnityEngine;
using System.Collections;

public class Gui2ui : MonoBehaviour {
	
	public GUIStyle customGuiStyle;
	
	void OnGUI(){
		
		//EarlyFlightModel target = transform.parent.gameObject.GetComponent<EarlyFlightModel>();
		//GUI.Box (new Rect (0,0,200,50), "Left Horizontal: " + Input.GetAxis ("LeftHorizontal"), customGuiStyle);
		//GUI.Box (new Rect (0,20,200,50), "Left Vertical: " + Input.GetAxis ("LeftVertical"), customGuiStyle);
		//GUI.Box (new Rect (0,40,200,50), "Right Horizontal: " + Input.GetAxis ("RightHorizontal"), customGuiStyle);
		//GUI.Box (new Rect (0,60,200,50), "Right Vertical: " + Input.GetAxis ("RightVertical"), customGuiStyle);
		GUI.Box (new Rect (0,0,200,50), "Fire1: " + Input.GetButton("Fire1"), customGuiStyle);
		GUI.Box (new Rect (0,20,200,50), "Fire2: " + Input.GetButton("Fire2"), customGuiStyle);
		GUI.Box (new Rect (0,40,200,50), "Fire3: " + Input.GetButton("Fire3"), customGuiStyle);
		GUI.Box (new Rect (0,60,200,50), "Fire4: " + Input.GetButton("Fire4"), customGuiStyle);
		GUI.Box (new Rect (0,80,200,50), "Fire5: " + Input.GetButton("Fire5"), customGuiStyle);
		GUI.Box (new Rect (0,100,200,50), "Fire6: " + Input.GetButton("Fire6"), customGuiStyle);
		GUI.Box (new Rect (0,120,200,50), "Fire7: " + Input.GetButton("Fire7"), customGuiStyle);
	}

}
