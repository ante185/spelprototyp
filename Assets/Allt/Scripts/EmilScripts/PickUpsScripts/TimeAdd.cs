using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAdd : MonoBehaviour
{
    public bool timeIncrease = false;


    /*
        public Display pickUps;
        private float delay = 5.0f;
        private Renderer mesh;

        private Collider meshC;


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

        */
    void OnCollisionEnter(Collision other)
    {
        

        if (other.gameObject.CompareTag("Player"))
        {


           
               
               




            //pickUps.addTime();




            //mesh.enabled = false;
            //meshC.enabled = false;
            timeIncrease = true;


        }



    }

}




    
