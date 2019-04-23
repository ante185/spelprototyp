using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Display : MonoBehaviour {


    private float time;
    public load gamending;
    public Text timePassed;
    public int timePassedAsInt;
    public Text speed;
    public VehicleMovement2 vehicleStats;
    public bool timeStop = false;



 

    // Update is called once per frame
    void Update()
    {
        if (gamending.gameEnd)
        {
            time += 0;
            timeStop = true;
        }
        time += Time.deltaTime;
        timePassedAsInt = (int)time;
        timePassed.text = "Time: " + timePassedAsInt.ToString();

        speed.text = "Velocity: " + vehicleStats.getcurrentSpeed().ToString();


    }



    public void addTime()
    {
        time += 5.0f;
    }



}
