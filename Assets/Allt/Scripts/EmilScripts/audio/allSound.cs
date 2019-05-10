using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allSound : MonoBehaviour {

    public AudioClip engineStart;
    public AudioClip badPickup;
    public AudioClip GameOver;
    public AudioClip reverse;
    public AudioClip forward;
    public AudioClip completedLap;
    public AudioClip lostMedal;
    public AudioClip respawn;
    public AudioClip goodPickup;
    public AudioClip takingDamage;
    public AudioSource source;

	void Start ()
    {
        source = GetComponent<AudioSource>();

     

    }

    private void Update()
    {
        
        
        
    }
}
