using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPC : MonoBehaviour
{
    
    public bool passed = false;
    public bool collision = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(passed)
            {
                collision = true;
                passed = false;
                
            }
        }





    }

}
