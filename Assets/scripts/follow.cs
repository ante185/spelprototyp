using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {

    public Transform[] walls;
    public Transform target;

    public float distance = 5.0f;

    public static follow Instance;

    public float height = 5.0f;

    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    public float offset = 1;
    public float offsetTwo = -1;
    private Vector3 temp;
    // Use this for initialization
    void Start () {
        Instance = this;


       


	}

    //  private void OnCollisionEnter(Collision collision)
    //{
    //  transform.position = tempTwo;
    //}



    private void Update()
    {
       




    }




    // Update is called once per frame
    void LateUpdate () {
        if (!target)
        {
            return;
        }
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        temp = transform.position;
        temp.y = currentHeight;

        RaycastHit wall;
        Ray wallHitRight = new Ray(transform.position, Vector3.right);
        Ray wallHitLeft = new Ray(transform.position, Vector3.left);

        for (int i = 0; i < 24; i++)
        {
            if (Physics.Raycast(wallHitRight, out wall, offset))
            {
                if (wall.collider.tag == i.ToString())
                {


                    temp.x = wall.point.x;



                }
            }

            if (Physics.Raycast(wallHitLeft, out wall, offsetTwo))
            {
                if (wall.collider.tag == i.ToString())
                {

                    temp.x = wall.point.x;




                }
            }



        }



        transform.position = temp;
        transform.LookAt(target);

        /*  for(int i=0; i<24; i++)
          {

              if (transform.position.x >= walls[i].transform.position.x - 4)
              {
                  temp.x = walls[i].transform.position.x + 1;


              }
              if (transform.position.x <= walls[i].transform.position.x + 4)
              {
                  temp.x = walls[i].transform.position.x - 1;

              }



          }


      */
        



            





        //tempTwo = temp;
       
            
     
        

        
	}



}
