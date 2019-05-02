using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedReduction : MonoBehaviour
{
    public bool speedredu = false;
    /* public VehicleMovement2 player;
     private float delay = 5.0f;
     //public PickUpManager pum;

     private Renderer mesh;
     private float reduceTimer;
     private Collider meshC;
     private void Start()
     {
         mesh = GetComponent<MeshRenderer>();
         meshC = GetComponent<CapsuleCollider>();



     }

     private void Update()
     {



             if (speedredu)
             {
                 reduceTimer += Time.deltaTime;

                 if (reduceTimer > delay)
                 {








                     player.maxSpeed+= 2.5f;
                     player.increaseSpeed();
                     reduceTimer = 0.0f;
                     mesh.enabled = true;
                     meshC.enabled = true;
                     speedredu = false;

                 }



             }









     }

     */
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            /*  if (speedredu == false)
              {
                  player.maxSpeed -= 2.5f;
                  player.decreaseSpeed();
              }

              // pum.setTrue(gameObject);


              mesh.enabled = false;
              meshC.enabled = false;


      */


            speedredu = true;






        }




    }





     

     




}
