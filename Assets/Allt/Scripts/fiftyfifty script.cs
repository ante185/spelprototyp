using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fiftyfiftyscript : MonoBehaviour {

    private Renderer mesh;
    private Collider collider;

    // Use this for initialization
    void Start ()
    {
        mesh = GetComponent<MeshRenderer>();
        collider = GetComponent<BoxCollider>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Player"))
        {
            mesh.enabled = false;
            collider.enabled = false;
        }



    }
}
