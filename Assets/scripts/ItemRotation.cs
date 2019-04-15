using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour {


    private Vector3 rotation;
    private bool alive = true;
    public carClass vehicle;
    float timePassed = 0.0f;


	// Use this for initialization
	void Start () {
        rotation.x = 0;
        rotation.y = 0;
        rotation.z = 1;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(rotation);
		
        
  


        /*if(vehicle.getItem()==false)
        {

            
            timePassed += Time.deltaTime;
            if(timePassed>5.0f)
            {
                
                vehicle.setItem();
            }


        }
        */


	}
}
