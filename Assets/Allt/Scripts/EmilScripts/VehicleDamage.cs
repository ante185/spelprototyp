using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDamage : MonoBehaviour
{
    public int health = 20;
    public VehicleMovement2 vehicle;
    public allSound sound;
    public float rayDistance = 0.5f;

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

        if (Physics.Raycast(transform.position, right, out hit, rayDistance) && vehicle.getcurrentSpeed() >=5 && hit.transform.tag!="pickUp")
        {
            health -= 1;

            sound.source.PlayOneShot(sound.takingDamage);

        }




        if (Physics.Raycast(transform.position, left, out hit, rayDistance) && vehicle.getcurrentSpeed() >= 5 && hit.transform.tag != "pickUp")
        {
            health -= 1;
            sound.source.PlayOneShot(sound.takingDamage);
        }
        if (Physics.Raycast(transform.position, back, out hit, rayDistance) && vehicle.getcurrentSpeed() >= 5 && hit.transform.tag != "pickUp")
        {

            health -= 1;
            sound.source.PlayOneShot(sound.takingDamage);
        }

         if (Physics.Raycast(transform.position, forward, out hit, rayDistance) && vehicle.getcurrentSpeed() >= 5 && hit.transform.tag != "pickUp")
         {
            health -= 1;
            sound.source.PlayOneShot(sound.takingDamage);
        }
      


    }


}
