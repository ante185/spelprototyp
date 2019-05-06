﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Medals : MonoBehaviour
{
    public int goldMedal = 60;
    public int silverMedal = 80;
    public int bronzeMedal = 105;
    public Text text;
    public Display display;
    private int getTime;
    private int getSize;
    private float clock;
    private bool switchBack = false;
    private Color getC;
    private bool silverSwitch = false;
    private bool bronzeSwitch = false;

    public bool silverr;
    public bool bronzee;
    public bool nothing;
   
    


    private void Start()
    {
        silverr = false;
        bronzee = false;
        nothing = false;
        text.text = "To Win Gold: " + goldMedal.ToString();
        getSize = text.fontSize;
        getC = text.color;
    }
    private void Update()
    {
        getTime = display.timePassedAsInt;
        if (getTime>goldMedal-10 &&switchBack==false)
        {
            switchToAnotherColor();
            clock += Time.deltaTime;

            if (clock > 10.0f)
            {
                text.color = getC;
                text.fontSize = getSize;
                clock = 0.0f;
                silver();
                silverr = true;
                switchBack = true;
            }
            


        }
        if (getTime > silverMedal - 10 && silverSwitch == false)
        {
            switchToAnotherColor();
            if (clock > 10.0f)
            {
                text.color = getC;
                text.fontSize = getSize;
                clock = 0.0f;
                bronze();
                silverr = false;
                bronzee = true;
                silverSwitch = true;
            }


        }
        if (getTime > bronzeMedal - 10 && bronzeSwitch == false)
        {
            switchToAnotherColor();
            if (clock > 10.0f)
            {
                text.color = getC;
                text.fontSize = getSize;
                clock = 0.0f;
                timesUp();
                bronzee = false;
                nothing = true;
                bronzeSwitch = true;
            }


        }



    }
    private void timesUp()
    {
        text.text = "Out of Time For a Medal :(";


    }
    private void bronze()
    {
        text.text = "The Goal for Bronze is: " + bronzeMedal.ToString();
    }

    private void silver()
    {
        text.text = "You can still win Silver! " + silverMedal.ToString();



    }
  
    private void switchToAnotherColor()
    {
        text.color = Color.red;
        text.fontSize = (int)(getSize * 1.5);
      

    }

}
