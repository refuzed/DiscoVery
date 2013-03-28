using UnityEngine;
using System.Collections;

public class Gui2ui : MonoBehaviour {
	
	public float speed = 0;
	public GUIStyle customGuiStyle;
	
	void OnGUI(){
		
		EarlyFlightModel target = transform.parent.gameObject.GetComponent<EarlyFlightModel>();
		GUI.Box (new Rect (0,0,200,50), "Relative Speed: " + Mathf.Round(target.speed*10), customGuiStyle);

	}

}
