using UnityEngine;
using System.Collections;

public class BulletTrash : MonoBehaviour {
	
	public float DestructTimeout;
	
    void Update ()  
    {  
        if(!IsInvoking("AutoDestruct"))  
        {  
            Invoke("AutoDestruct",DestructTimeout);  
        }  
  
    }  
  
    void AutoDestruct()  
    {  
        Destroy(gameObject);  
    }  
}
