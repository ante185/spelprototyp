using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour {

    public List<TimeAdd> timeAdd;
    public List<SpeedBoost> speedBoost;
    public List<SpeedReduction> speedReduction;
    private int nrOfTime;
    private int nrOfSpeedB;
    private int nrOfspeedR;
    public VehicleMovement2 player1;
   
    public Display timeToAdd;
    private float delay = 5.0f;
    



    // Use this for initialization
    void Start () {
        nrOfTime = timeAdd.Capacity;
        nrOfspeedR = speedReduction.Capacity;
        nrOfSpeedB = speedBoost.Capacity;


        




	}
	
	// Update is called once per frame
	void Update () {
		

        for(int i=0; i<nrOfTime; i++)
        {
            if(timeAdd[i].timeIncrease)
            {
                timeAdd[i].gameObject.SetActive(false);
                timeToAdd.addTime();
                activation(0.0f, timeAdd[i].gameObject);

                if(timeAdd[i].gameObject.activeSelf==true)
                {
                    timeAdd[i].timeIncrease = false;
                }

                




            }



        }

        for (int i = 0; i < nrOfspeedR; i++)
        {
            if(speedReduction[i].speedredu)
            {
                speedReduction[i].gameObject.SetActive(false);
                player1.maxSpeed -= 2.5f;
                player1.decreaseSpeed();
                activation(0.0f, speedReduction[i].gameObject);

                if(speedReduction[i].gameObject.activeSelf==true)
                {
                    player1.maxSpeed += 2.5f;
                    player1.increaseSpeed();
                    speedReduction[i].speedredu = false;
                }
                

                



            }



        }

        for (int i = 0; i <nrOfSpeedB; i++)
        {
            if(speedBoost[i].speedIncr)
            {
                speedBoost[i].gameObject.SetActive(false);
                player1.maxSpeed += 2.5f;
                player1.increaseSpeed();
                activation(0.0f, speedBoost[i].gameObject);

                if(speedBoost[i].gameObject.activeSelf==true)
                {
                    player1.maxSpeed -= 2.5f;
                    player1.decreaseSpeed();
                    speedBoost[i].speedIncr = false;


                }



            }



        }

    }

    private void activation(float time, GameObject pickUp)
    {
        time += Time.deltaTime;

        if(time>delay)
        {
            pickUp.SetActive(true);

            


            time = 0.0f;
        }


    }
 




}
