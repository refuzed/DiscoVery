using UnityEngine;
using System.Collections;

public class DiscoFevah : MonoBehaviour {
	
	
	public float timeMod;
	
	public int colorIndex;
	private Color[] colorPath = new Color[] { Color.blue, Color.cyan, 
											  Color.green, Color.yellow, 
											  Color.red, Color.magenta, Color.grey };
	
	public int lightIndex;
	private Vector3[] lightPath = new Vector3[] { new Vector3(675,20,720),
											      new Vector3(735,20,720),
											      new Vector3(700,20,720),
											      new Vector3(690,20,700),
											      new Vector3(735,20,720),
											      new Vector3(680,20,750),	
												  new Vector3(705,20,775) };
	private float intensityTarget;
	
	void Start () 
	{
		RandomizeMods();
		transform.position = lightPath[lightIndex];
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
			RandomizeMods();
		
		UpdateColor();
		UpdateIntensity();
		RotateLights();
	}
	
	void UpdateColor() 
	{
		if(light.color == colorPath[colorIndex])
			colorIndex = Random.Range(0,colorPath.Length);
		light.color = Color.Lerp(light.color, colorPath[colorIndex],Time.fixedDeltaTime * timeMod);
	}
	
	void UpdateIntensity() 
	{
		if(light.intensity <= 0.55f)
			intensityTarget = 1.5f;
		if(light.intensity >= 1.45f)
			intensityTarget = 0.5f;
		
		light.intensity = Mathf.Lerp(light.intensity, intensityTarget, Time.fixedDeltaTime * timeMod);
	}
	
	void RotateLights()
	{
		if(Vector3.Distance(transform.position,lightPath[lightIndex]) < 1.55f)
			lightIndex = Random.Range(0,lightPath.Length);
		
		transform.position = Vector3.Lerp(transform.position, lightPath[lightIndex], Time.fixedDeltaTime * timeMod / 10.0f);
	}
	
	void RandomizeMods()
	{
		timeMod = Random.Range(0f,15f);
		colorIndex = Random.Range(0,colorPath.Length);
		lightIndex = Random.Range(0,lightPath.Length);
	}
	
}
