using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedReduction : MonoBehaviour
{
    public VehicleMovement2 player;
    private float delay = 5.0f;
   
    private bool speedredu = false;
    
    private float reduceTimer;
    

    private void Update()
    {

        

            if (speedredu)
            {
                reduceTimer += Time.deltaTime;

                if (reduceTimer > delay)
                {


                    gameObject.SetActive(true);





                    player.maxSpeed+= 2.5f;
                    reduceTimer = 0.0f;
                    speedredu = false;

                }



            }




        




    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

           
                
                speedredu = true;
                




           



            gameObject.SetActive(false);
            player.maxSpeed -= 2.5f;
        }




    }





     

     




}
