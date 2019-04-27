using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Medals : MonoBehaviour
{
    private int goldMedal = 60;
    private int silverMedal = 80;
    private int bronzeMedal = 105;
    public Text text;
    public Display display;
    private int getTime;
    private int getSize;
    private float clock;
    private bool switchBack = false;
    private Color getC;
    private bool silverSwitch = false;
    private bool bronzeSwitch = false;

    private void Start()
    {
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
