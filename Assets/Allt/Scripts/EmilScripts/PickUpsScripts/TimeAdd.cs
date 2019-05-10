using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAdd : MonoBehaviour
{

    public Display pickUps;
    private float delay = 5.0f;
    private Renderer mesh;
    
    private Collider meshC;
    public allSound sound;
    public bool timeIncrease = false;
    private float itemTime;


    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        meshC = GetComponent<BoxCollider>();



    }



    private void Update()
    {
        

            if (timeIncrease)
            {
                itemTime += Time.deltaTime;

                if (itemTime > delay)
                {


                    


                
                    itemTime = 0.0f;
                mesh.enabled = true;
                meshC.enabled = true;
                timeIncrease = false;

                }

            }








       



    }
 

    void OnCollisionEnter(Collision other)
    {
        

        if (other.gameObject.CompareTag("Player"))
        {








            sound.source.PlayOneShot(sound.badPickup);
            pickUps.addTime();




            mesh.enabled = false;
            meshC.enabled = false;
            timeIncrease = true;


        }



    }

}




    
