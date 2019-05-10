using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuAndGameOver : MonoBehaviour {

    public AudioClip bgMusic;
    private AudioSource source;

	void Start ()
    {
        source = GetComponent<AudioSource>();

        source.loop = true;

    }

    private void Update()
    {
        
        source.PlayOneShot(bgMusic);
        
    }
}
