using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class timeLoad : MonoBehaviour
{
    private BinaryFormatter bF = new BinaryFormatter();
    private ClassA lastTime;
    public Text text;
    private FileStream fS;
    public int timeToGive;
    private void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "HighScoreTwo.dat"))
        {
            fS = File.Open(Application.persistentDataPath + "HighScoreTwo.dat", FileMode.Open);

            lastTime = (ClassA)bF.Deserialize(fS);


            text.text = "Your time: " + lastTime.finalTime.ToString() + "\n\n"+"Nr Of Completed Laps: " + lastTime.nrOfLaps.ToString();

            timeToGive = lastTime.finalTime;


            fS.Close();
        }




    }

}
