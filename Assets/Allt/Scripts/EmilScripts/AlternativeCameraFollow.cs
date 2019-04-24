using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeCameraFollow : MonoBehaviour {

    public Transform target;
    public float y = 2;
    public float z = 5;
    private Vector3 desiredPos;
    public float smoothing = 0.125f;
    public float rayDistance = 1.0f;
    private Vector3 velocity = Vector3.zero;
    private Quaternion rotation;
    private bool test = false;





    private void courseCorrection(ref Vector3 wantedPos)
    {
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 left = transform.TransformDirection(Vector3.left);
        Vector3 back = transform.TransformDirection(Vector3.back);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        
            if (Physics.Raycast(transform.position, right, out hit, rayDistance))
            {
                //wantedPos = new Vector3(hit.point.x + 1, wantedPos.y, wantedPos.z);
                test = true;
            }




            if (Physics.Raycast(transform.position, left, out hit, rayDistance))
            {
                //wantedPos = new Vector3(hit.point.x - 1, wantedPos.y, wantedPos.z);
                test = true;
            }
            if (Physics.Raycast(transform.position, back, out hit, rayDistance))
            {
                //wantedPos = new Vector3(hit.point.x - 1, wantedPos.y, wantedPos.z);
                test = true;
            }

        if (Physics.Raycast(transform.position, forward, out hit, rayDistance, 9))
        {
            //wantedPos = new Vector3(hit.point.x - 1, wantedPos.y, wantedPos.z);
            test = true;
        }


















    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rotation = transform.rotation;
        desiredPos = target.position + Vector3.up * y - target.forward * z;




        courseCorrection(ref desiredPos);

        if(test==false)
        {
            transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothing);

            transform.LookAt(target);


        }
        else if(test)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothing);
            transform.LookAt(target);
            test = false;
        }
       


    }
}
