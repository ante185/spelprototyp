using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPL : MonoBehaviour {

    public Vector3 previousCheckpointPos;
    public Quaternion previousCheckpointRot;
    public VehicleMovement2 player;
    public VehicleDamage playerDamage;
    private int basicHealth;
    public List<CPC> checkpoints;
    private int nrOf;
    public int counter = 0;


    // Use this for initialization
    void Start()
    {
        basicHealth = playerDamage.health;
        nrOf = checkpoints.Capacity;
        if (nrOf > 0)
        {
            previousCheckpointPos = checkpoints[0].transform.position;
            previousCheckpointRot = player.transform.rotation;

        }

    }

    // Update is called once per frame
    void Update()
    {


        for (int i = 0; i < nrOf; i++)
        {



            if (checkpoints[i].collision)
            {
                if (i == 0)
                {
                    counter += 1;
                    previousCheckpointPos = checkpoints[i].transform.position;
                    checkpoints[i + 1].passed = true;
                    checkpoints[i].collision = false;
                }

                else if (i != nrOf - 1 && i != 0)
                {
                    previousCheckpointPos = checkpoints[i].transform.position;
                    checkpoints[i + 1].passed = true;
                    checkpoints[i].collision = false;




                }
                else if (i == nrOf - 1)
                {
                    previousCheckpointPos = checkpoints[i].transform.position;
                    checkpoints[0].passed = true;
                    checkpoints[i].collision = false;

                }



            }



        }


        if (playerDamage.health <= 0)
        {
            if (nrOf > 0)
            {
                player.transform.position = previousCheckpointPos;
                player.transform.rotation = previousCheckpointRot;
            }

            playerDamage.health = basicHealth;


        }






    }
}
