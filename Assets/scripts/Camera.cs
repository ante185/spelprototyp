using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Collider[] walls;
    public Transform target;
    public float y = 2;
    public float z = 5;
    private Vector3 vehiclePos;
    public float smoothing;
    public float rightFront = 2;
    public float leftBack = -2;
    void Start ()
    {
    
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {

        vehiclePos = target.position + Vector3.up * y - target.forward * z;

         wallCollision(ref vehiclePos);

       // wallCollisionTwo(target.position, ref vehiclePos);
        transform.position = Vector3.Lerp(transform.position, vehiclePos, Time.deltaTime * smoothing);

        transform.LookAt(target);


    }


    private void wallCollision(ref Vector3 whereToBe)
    {

       RaycastHit wall;
        Ray wallHitRight = new Ray(transform.position, Vector3.right);
        Ray wallHitLeft = new Ray(transform.position, Vector3.left);
        Ray wallHitFront = new Ray(transform.position, Vector3.forward);
        Ray wallHitBack = new Ray(transform.position, Vector3.back);

        for (int i = 0; i < 24; i++)
        {
            if (Physics.Raycast(wallHitRight, out wall, rightFront))
            {
                if (wall.collider.tag == i.ToString())
                {


                    whereToBe = new Vector3(wall.point.x, wall.point.y, wall.point.z);



                }
            }

            if (Physics.Raycast(wallHitLeft, out wall, leftBack))
            {
                if (wall.collider.tag == i.ToString())
                {


                    whereToBe = new Vector3(wall.point.x, wall.point.y, wall.point.z);



                }
            }


            if (Physics.Raycast(wallHitFront, out wall, rightFront))
            {
                if (wall.collider.tag == i.ToString())
                {


                    whereToBe = new Vector3(wall.point.x, wall.point.y, wall.point.z);



                }
            }

            if (Physics.Raycast(wallHitBack, out wall, leftBack))
            {
                if (wall.collider.tag == i.ToString())
                {


                    whereToBe = new Vector3(wall.point.x, wall.point.y, wall.point.z);



                }
            }





        }


       



        
       

          




    }
    private void wallCollisionTwo(Vector3 whatToLookAt, ref Vector3 whereToBe)
    {

        RaycastHit wall = new RaycastHit();



        if (Physics.Linecast(whatToLookAt, whereToBe, out wall))
        {
            whereToBe = new Vector3(wall.point.x, wall.point.y, wall.point.z);








        }




    }

}
