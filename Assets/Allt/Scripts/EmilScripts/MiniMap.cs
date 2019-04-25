using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour {
    public Transform player;
    public float offsetY = 350;
	// Update is called once per frame
	void LateUpdate ()
    {
        Vector3 playPos = player.position;

        playPos.y = offsetY;

        transform.position = playPos;



        transform.LookAt(player);





		
	}
}
