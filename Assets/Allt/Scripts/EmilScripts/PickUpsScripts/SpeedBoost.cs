using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    VehicleMovement2 player;
    private float delay = 5.0f;
    private const int nrOf = 50;
    private bool speedIncr = false;
    
    private float boostTimer; 
   



    private void Update()
    {
        
            if (speedIncr)
            {
                boostTimer += Time.deltaTime;
                if (boostTimer > delay)
                {


                    gameObject.SetActive(true);





                    player.decreaseSpeed();
                    boostTimer = 0.0f;
                    speedIncr = false;
                }

            }




        




    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            
                
                speedIncr = true;
               




            



            gameObject.SetActive(false);
            player.increaseSpeed();
        }




    }


      

}
