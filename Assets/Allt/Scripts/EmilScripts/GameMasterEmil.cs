using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

/*
    FÖR ATT DETTA SCRIPT SKA FUNGERA BEHÖVS OCKSÅ Checkpoint.cs OCH PlayerPos.cs
    Skapa ett empty object (Rekomenderat namn GameMaster). objektet behöver ingen specifik position eller storlek.
    lägg till scriptet i objektet och sätt "Last Checkpoint Pos" till de exakta kordinaterna som spearen sak börja på.
    Skapa en ny Tag för GameMaster och döp den till "GM". Detta är för senare!
    Last Checkpoint Rot bör lämnas som den är.

*/

public class GameMasterEmil : MonoBehaviour
{
    public string completeList;
    private hss[] listScores = new hss[10];
    private int nrOf = 0;
    public Display clock;
    private int time;
    public Vector3 lastCheckpointPos;
    public Quaternion lastCheckpointRot;
    private bool saveVar = false;

   

  

    private void Update()
    {
        if (clock.timeStop)
        {
            time = clock.timePassedAsInt;
        }
        
    }

    public void save()
    {
        hss highScore = new hss();
        highScore.time = time;
        highScore.name = " ";
        if(nrOf > 9)
        {
            if (highScore.time < listScores[nrOf].time)
            {
                listScores[nrOf] = highScore;
                nrOf += 1;
            }
        }
       else if(nrOf < 10)
        {
            listScores[nrOf] = highScore;
            nrOf += 1;
        }

        

        for (int i = 0; i < nrOf - 1; i++)
        {
            int smallest = i;

            for (int j = i + 1; j < nrOf; j++)
            {
                if (listScores[j].time < listScores[smallest].time)
                {
                    smallest = j;


                }



            }

            hss temp = listScores[smallest];
            listScores[smallest] = listScores[i];
            listScores[i] = temp;


        }

        for(int k=0; k<nrOf; k++)
        {
            completeList += listScores[k].name + " " + listScores[k].time.ToString() + "\n\n";




        }

        //BinaryFormatter bF = new BinaryFormatter();
        FileStream fS = File.Create(Application.persistentDataPath + "HighScore.dat");

        //bF.Serialize(fS, completeList);


        //File.CreateText(Application.persistentDataPath + "HighScore.dat");

        File.WriteAllText(Application.persistentDataPath + "HighScore.dat", completeList);

        fS.Close();


    }
    public void loading()
    {

        if(File.Exists(Application.persistentDataPath + "HighScore.dat"))
        {
            //BinaryFormatter bf = new BinaryFormatter();
            FileStream fS = File.Open(Application.persistentDataPath + "HighScore.dat", FileMode.Open);
            //completeList = bf.Deserialize(fS);
            completeList = fS.ToString();
            fS.Close();
        }


    }

    private void toSave()
    {
        saveVar = true;
    }


}

class hss
{

    public int time;
    public string name;



}
