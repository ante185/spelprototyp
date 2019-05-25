using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public VehicleMovement2 player;
    private float delay = 5.0f;
    private const int nrOf = 50;
    public bool speedIncr = false;
    public allSound sound;
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
                    player.resetMaxSpeed();
                    boostTimer = 0.0f;
                    mesh.enabled = true;
                    meshC.enabled = true;
                    speedIncr = false;
                }

            }




        




    }
  

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {













            sound.source.PlayOneShot(sound.goodPickup);
            player.updateVelocity(15.0f / Time.deltaTime);
            player.maxSpeed += 10;


            mesh.enabled = false;
            meshC.enabled = false;



            speedIncr = true;
        }




    }


      

}
