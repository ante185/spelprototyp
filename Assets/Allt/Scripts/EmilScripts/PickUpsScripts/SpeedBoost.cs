using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public VehicleMovement2 player;
    private float delay = 5.0f;
    private const int nrOf = 50;
    public bool speedIncr = false;
    
    private float boostTimer;
    private Renderer mesh;

    private Collider meshC;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        meshC = GetComponent<SphereCollider>();



    }

    private void Update()
    {
        
            if (speedIncr)
            {
            
                boostTimer += Time.deltaTime;
                if (boostTimer > delay)
                {


                   





                    player.decreaseSpeed();
                    player.maxSpeed -= 10;
                    boostTimer = 0.0f;
                mesh.enabled = true;
                meshC.enabled = true;
                speedIncr = false;
                }

            }




        




    }
  

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            
                
               








            
            
            player.increaseSpeed();
            player.maxSpeed += 10;


            mesh.enabled = false;
            meshC.enabled = false;



            speedIncr = true;
        }




    }


      

}
