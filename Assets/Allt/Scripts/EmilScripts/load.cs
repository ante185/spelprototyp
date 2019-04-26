using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{
    public bool gameEnd = false;
    public CheckpointEmil startAndFinish;
    
    public Display finalTimer;
    
    private int finalTimee;
    private ClassA classToHoldTime = new ClassA();
    private BinaryFormatter bF = new BinaryFormatter();
    private FileStream fS;


    private void Update()
    {
       



        if(startAndFinish.counter>=2)
        {
           gameEnd = true;

            finalTimee = finalTimer.timePassedAsInt;
            classToHoldTime.finalTime = finalTimee;

            if (File.Exists(Application.persistentDataPath + "HighScoreTwo.dat"))
            {
                fS = File.Open(Application.persistentDataPath + "HighScoreTwo.dat", FileMode.Open);
            }
            else
            {
                fS = File.Create(Application.persistentDataPath + "HighScoreTwo.dat");
            }

            bF.Serialize(fS, classToHoldTime);

            fS.Close();






            //yield return new WaitForSeconds(3);
            endGame();
        }


    }


  
    

    public void endGame()
    {

        
        SceneManager.LoadScene(2);





        



    }
        



}
