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
            GetComponent<GameObject>().SetActive(false);

        }
        if (time.timeToGive <= 540)
        {
            GetComponent<Image>().sprite = gold;

        }
        if (time.timeToGive <= 600 && time.timeToGive > 540)
        {
            GetComponent<Image>().sprite = silver;

        }
        if (time.timeToGive <= 660 && time.timeToGive > 600)
        {
            GetComponent<Image>().sprite = bronze;

        }


    }
	
	
}
