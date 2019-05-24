using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Medals : MonoBehaviour
{
    public int goldMedal = 120;
    public int silverMedal = 150;
    public int bronzeMedal = 180;
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

    public allSound sound;

    private bool silverSound;
    private bool bronzeSound;
    private bool nothingSound;
    


    private void Start()
    {
        silverr = false;
        bronzee = false;
        nothing = false;
        text.text = "Finish the Game within: " + goldMedal.ToString() + "\nseconds,\nto win a Goldmedal!";
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

                if (silverSound == false)
                {
                    sound.source.PlayOneShot(sound.lostMedal);
                    silverSound = true;
                }


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

                if (bronzeSound == false)
                {
                    sound.source.PlayOneShot(sound.lostMedal);
                    bronzeSound = true;
                }
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
                if (nothingSound == false)
                {
                    sound.source.PlayOneShot(sound.lostMedal);
                    nothingSound = true;
                }
            }


        }



    }
    private void timesUp()
    {
        text.text = "Out of Time For a Medal :(";


    }
    private void bronze()
    {
        text.text = "Finish the Game within: " + bronzeMedal.ToString() + "\nseconds,\nto win a Bronzemedal!";
    }

    private void silver()
    {
        text.text = "Finish the Game within: " + silverMedal.ToString() + "\nseconds,\nto win a Silvermedal!";



    }
  
    private void switchToAnotherColor()
    {
        text.color = Color.red;
        text.fontSize = (int)(getSize * 1.5);
      

    }

}
