using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDamage : MonoBehaviour
{
    public int health = 100;
    public VehicleMovement2 vehicle;
    public allSound sound;
    public switchTex2 textSwitch;
    private int baseHealth;
    

    private void Start()
    {
        baseHealth = health;
    }

   
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "hinder")
        {
            health = health - 20;

            sound.source.PlayOneShot(sound.takingDamage);

            if(health<baseHealth/2)
            {
                textSwitch.takingDamage();


            }
            else
            {
                textSwitch.notTakingDamage();
            }

        }

        


    }





}
