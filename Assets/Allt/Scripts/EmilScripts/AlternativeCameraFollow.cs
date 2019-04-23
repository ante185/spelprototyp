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






    private void courseCorrection(ref Vector3 wantedPos)
    {
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 left = transform.TransformDirection(Vector3.left);
        RaycastHit hit;

        if (rotation.y >= -45 && rotation.y <= 45)
        {
            if (Physics.Raycast(transform.position, right, out hit, rayDistance))
            {
                wantedPos = new Vector3(hit.point.x + 1, wantedPos.y, wantedPos.z);

            }




            if (Physics.Raycast(transform.position, left, out hit, rayDistance))
            {
                wantedPos = new Vector3(hit.point.x - 1, wantedPos.y, wantedPos.z);

            }




        }















    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rotation = transform.rotation;
        desiredPos = target.position + Vector3.up * y - target.forward * z;




        courseCorrection(ref desiredPos);

        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothing);

        transform.LookAt(target);


    }
}
