using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    FÖR ATT DETTA SCRIPT SKA FUNGERA BEHÖVS OCKSÅ GameMaster.cs OCH PlayerPos.cs
    Skapa Empty Objects ,dessa objekten kommer bli våra checkpoints, så antalet objekt beror på antalet önskade checkpoint.
    Placera ut de där checkpointen ska vara (Ifall det inte redan var självklart).
    Skapa en Box Collider för varje objekt och bocka i "Is Trigger".
    lägg in Checkpoint Scriptet i varje checkpoint objekt.
 
*/

public class CheckpointEmil : MonoBehaviour {

    private GameMaster gm;
    public int counter;
    public bool passedPreviousPoint = false;
    public CheckpointEmil otherCP;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    //Funktionen kallas efter att spelaren har koliderat med ett annat objekt
    void OnTriggerEnter(Collider other)
    {
        //Om det andra objektet har taggen Player
        if(other.CompareTag("Player"))
        {
            //Hämtar information angående position och rotation från den senaste checkpointen
            gm.lastCheckpointPos = transform.position;
            gm.lastCheckpointRot = transform.rotation;

            if (otherCP.passedPreviousPoint)
            {
                otherCP.counter = otherCP.counter + 1;
                otherCP.passedPreviousPoint = false;
                passedPreviousPoint = true;
                

            }


        }
    }

   
        
   



}
