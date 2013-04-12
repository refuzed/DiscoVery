using UnityEngine;
using System.Collections;

public class PewPew : MonoBehaviour 
{
	private bool canShoot;
	private GameObject bullet; 
	private GameObject instantiatedBullet; 
	public Transform muzzle;
	
	void Start () 
	{
		bullet = (GameObject)Resources.Load("Bullet"); 
		canShoot = true;
	}
	
	void Update () 
	{
		if(Input.GetKey(KeyCode.F) || Input.GetButton ("Fire1"))
			Shoot();

	}
	
	void Shoot()
	{
		if(canShoot)
		{
			instantiatedBullet = (GameObject)Instantiate(bullet, muzzle.position, muzzle.rotation);  
		    instantiatedBullet.rigidbody.velocity =  muzzle.TransformDirection(Vector3.forward * 175 ); 
			canShoot = false;
			Invoke ("ResetTimer", .2f);
		}
	}
	
	void ResetTimer()
	{
		canShoot = true;
	}
}
