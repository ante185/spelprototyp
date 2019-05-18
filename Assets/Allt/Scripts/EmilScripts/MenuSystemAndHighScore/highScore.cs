using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class highScore : MonoBehaviour
{
    private string completeList;
    private int latest;
    public Text text;
    private int lenght;
	// Use this for initialization
	void Start ()
    {
        latest = PlayerPrefs.GetInt("high");

        completeList = PlayerPrefs.GetString("complete");

        lenght= completeList.Split('\n').Length;
        


        if (completeList != null)
        {
            if (PlayerPrefs.GetInt("save") == 1)
            {
                if(lenght<12)
                {
                    completeList = completeList + "\n" + PlayerPrefs.GetString("name") + " " + latest.ToString();
                    PlayerPrefs.SetString("complete", completeList);

                }

                



            }


            

        }



        if (completeList==null)
        {
            completeList = "High Score";
            PlayerPrefs.SetString("complete", completeList);
        }

        if (PlayerPrefs.GetInt("save") == 1)
        {
            PlayerPrefs.SetInt("save", 0);



        }

    
        //PlayerPrefs.SetString("complete", "High Score");
        text.text = PlayerPrefs.GetString("complete");


	}
	
	
}
