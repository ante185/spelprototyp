using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 5;
    public float height = 5;

    // dämpnings variabler
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void LateUpdate () //LateUpdate: körs efter vanliga update funktioner
    {
        // Early out if we don't have a target
        if (!target)
        {
            return;
        }

        // Calculate the current rotation angles
         //Target 
        float wantedRotationAngle = target.eulerAngles.y; //Matte för vinkeln
        float wantedHeight = target.position.y + height; //Målets pos plus höjd över
         //this
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        //Dämpning
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
        // Damp the height
        currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        // Set the height of the camera using temp variable
        Vector3 temp = transform.position;
        temp.y = currentHeight;
        transform.position = temp;

        // Always look at the target
        transform.LookAt (target);
    }
}
