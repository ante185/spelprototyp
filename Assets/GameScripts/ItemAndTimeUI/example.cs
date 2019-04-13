using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class example : MonoBehaviour {
    public Display pickUps;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("timeReduction"))
        {
            other.gameObject.SetActive(false);
            pickUps.addTime();

        }
    }
}
