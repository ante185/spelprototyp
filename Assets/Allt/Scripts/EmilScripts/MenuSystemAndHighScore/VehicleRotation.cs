using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleRotation : MonoBehaviour
{
    private Vector3 rotate;

    private void Start()
    {
        //rotate.y = Time.deltaTime*4;
        rotate.y = 15;
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Rotate(rotate * Time.deltaTime);
        



	}
}
