using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAdd : MonoBehaviour
{

    public Display pickUps;
    private float delay = 5.0f;
    
   
    private bool timeIncrease = false;
    private float itemTime;


    private void Update()
    {
        

            if (timeIncrease)
            {
                itemTime += Time.deltaTime;

                if (itemTime > delay)
                {


                    gameObject.SetActive(true);



                    itemTime = 0.0f;
                    timeIncrease = false;

                }

            }








       



    }


    void OnCollisionEnter(Collision other)
    {
        

        if (other.gameObject.CompareTag("Player"))
        {


           
               
                timeIncrease = true;
                




           




            gameObject.SetActive(false);

            pickUps.addTime();

        }



    }

}




    
