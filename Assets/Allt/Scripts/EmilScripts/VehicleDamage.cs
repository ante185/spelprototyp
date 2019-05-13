using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDamage : MonoBehaviour
{
    public int health = 100;
    public VehicleMovement2 vehicle;
    public allSound sound;


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "hinder")
        {
            health = health - 10;
            sound.source.PlayOneShot(sound.takingDamage);




        }




    }





}
