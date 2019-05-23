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
    private int vel;
    public int laps;
    

 

    // Update is called once per frame
    void Update()
    {
        if (gamending.gameEnd)
        {
            time += 0;
            timePassedAsInt = (int)time;
            timeStop = true;
        }
        laps = gamending.getLaps();


        time += Time.deltaTime;
        timePassedAsInt = (int)time;
        timePassed.text = "Time: " + timePassedAsInt.ToString() + "\n\n" + "NrOfLaps: " + laps.ToString();

        vel = (int)vehicleStats.getcurrentSpeed();

        speed.text = "Thrust: " + vel.ToString();


    }



    public void addTime()
    {
        time += 5.0f;
    }



}
