using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Display : MonoBehaviour {


    private float time;

    public Text timePassed;
    private int timePassedAsInt;





	// Use this for initialization
	void Start ()
    {
      
	}
	
	// Update is called once per frame
	void Update ()
    {

        time += Time.deltaTime;
        timePassedAsInt = (int)time;
        timePassed.text = "Time: " + timePassedAsInt.ToString();


    }

 

    public void addTime()
    {
        time += 5.0f;
    }
  


}
