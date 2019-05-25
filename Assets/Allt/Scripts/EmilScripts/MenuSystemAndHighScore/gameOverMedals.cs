using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gameOverMedals : MonoBehaviour {

    public Sprite gold;
    public Sprite silver;
    public Sprite bronze;
    public timeLoad time;

    // Use this for initialization
    void Start () {
        
        
        if(time.timeToGive>180)
        {
            GetComponent<Image>().sprite = bronze;

        }
        if (time.timeToGive <= 120)
        {
            GetComponent<Image>().sprite = gold;

        }
        if (time.timeToGive <= 150 && time.timeToGive >120)
        {
            GetComponent<Image>().sprite = silver;

        }
        if (time.timeToGive <= 180 && time.timeToGive > 150)
        {
            GetComponent<Image>().sprite = bronze;

        }


    }
	
	
}
