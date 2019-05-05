using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {


    GameObject uiToPause;

    // Use this for initialization
    void Start () {

        uiToPause = GameObject.FindGameObjectWithTag("showOnPause");
        uiToPause.gameObject.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale==1)
            {
                uiToPause.gameObject.SetActive(true);
                Time.timeScale = 0;
                


            }
            else if(Time.timeScale==0)
            {
                uiToPause.gameObject.SetActive(false);
                Time.timeScale = 1;


            }



        }


    }
}
