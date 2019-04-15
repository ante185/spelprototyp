using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class example : MonoBehaviour {
    public Display pickUps;
    private float delay = 5.0f;
    private const int nrOf = 50;
    private float[] itemTime = new float[nrOf];
    GameObject[] item = new GameObject[nrOf];
    private bool[] timeIncrease = new bool[nrOf];
    private int counter = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        for (int j = 0; j < counter; j++)
        {

            if (timeIncrease[j])
            {
                itemTime[j] += Time.deltaTime;

                if (itemTime[j] > delay)
                {


                    item[j].SetActive(true);




                    timeIncrease[j] = false;
                    itemTime[j] = 0.0f;
                }

            }


        }



    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("timeReduction"))
        {


            if (item[counter] != other.gameObject)
            {
                item[counter] = other.gameObject;
                timeIncrease[counter] = true;
                counter += 1;




            }




            other.gameObject.SetActive(false);
            pickUps.addTime();
        }
    }
}
