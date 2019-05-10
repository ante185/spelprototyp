using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allSound : MonoBehaviour {

    public AudioClip engineStart;
    private AudioSource source;

	void Start ()
    {
        source = GetComponent<AudioSource>();

        //source.loop = true;

    }

    private void Update()
    {
        
        
        
    }
}
