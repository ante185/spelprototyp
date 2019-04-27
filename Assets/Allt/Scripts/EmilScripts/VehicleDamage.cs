using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDamage : MonoBehaviour
{
    public int health = 1000;
    public VehicleMovement2 vehicle;



    private void FixedUpdate()
    {
        takeDamage();
    }



    private void takeDamage()
    {
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 left = transform.TransformDirection(Vector3.left);
        Vector3 back = transform.TransformDirection(Vector3.back);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, right, out hit, 1) && vehicle.getcurrentSpeed() >=5)
        {
            health -= 1;
        }




        if (Physics.Raycast(transform.position, left, out hit, 1) && vehicle.getcurrentSpeed() >= 5)
        {
            health -= 1;
        }
        if (Physics.Raycast(transform.position, back, out hit, 1) && vehicle.getcurrentSpeed() >= 5)
        {

            health -= 1;
        }

         if (Physics.Raycast(transform.position, forward, out hit, 1) && vehicle.getcurrentSpeed() >= 5)
         {
            health -= 1;
        }
      


    }


}
