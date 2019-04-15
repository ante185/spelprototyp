using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    FÖR ATT DETTA SCRIPT SKA FUNGERA BEHÖVS OCKSÅ GameMaster.cs OCH Checkpoint.cs
    Sätt in skriptet i objektet som är spelaren.
    Sät Spelarens Tag till Player.
    
*/

public class PlayerPos : MonoBehaviour {

    private GameMaster gm;

    void Start()
    {
        //letar efter ett spelobjekt med Tagen "GM"
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckpointPos;
    }

    void Update()
    {

        // Ifall spelaren trycker ner space (Ändra detta för när skeppet är förstört)
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Spelaren hamnar på samma plats och samma riktning som den senaste checkpointen
            transform.position = gm.lastCheckpointPos;
            transform.rotation = gm.lastCheckpointRot; 
        }
    }
}
