using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class medalsImage : MonoBehaviour {


    public Sprite gold;
    public Sprite silver;
    public Sprite bronze;
    public Medals whenToSwitch;

	// Use this for initialization
	void Start () {
        GetComponent<Image>().sprite = gold;
	}
	
	// Update is called once per frame
	void Update () {

        if(whenToSwitch.silverr)
        {
            GetComponent<Image>().sprite = silver;
        }
        else if(whenToSwitch.bronzee)
        {
            GetComponent<Image>().sprite = bronze;
        }

		
	}
}
