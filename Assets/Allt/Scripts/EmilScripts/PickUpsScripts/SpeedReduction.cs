using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedReduction : MonoBehaviour
{
    public VehicleMovement2 player;
    private float delay = 5.0f;
    //public PickUpManager pum;
    public bool speedredu = false;
    private Renderer mesh;
    private float reduceTimer;
    private Collider meshC;
    public allSound sound;
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        meshC = GetComponent<BoxCollider>();



    }

    private void Update()
    {

        
        
            if (speedredu)
            {
                reduceTimer += Time.deltaTime;

                if (reduceTimer > delay)
                {







                
                    player.resetMaxSpeed();
                    reduceTimer = 0.0f;
                    mesh.enabled = true;
                    meshC.enabled = true;
                    speedredu = false;

                }



            }

   


        




    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (speedredu == false)
            {
                player.maxSpeed -= 2.5f;
                player.updateVelocity(-30.0f / Time.deltaTime);
            }

            // pum.setTrue(gameObject);

            sound.source.PlayOneShot(sound.badPickup);
            mesh.enabled = false;
            meshC.enabled = false;
            speedredu = true;
                




           



           
            
        }




    }





     

     




}
