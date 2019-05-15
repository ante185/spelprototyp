using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour {


    private Vector3 rotation;
    

	// Use this for initialization
	void Start () {
        rotation.x = 0;
        rotation.y = 50;
        rotation.z = 0;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(rotation * Time.deltaTime);
		
	}
}
