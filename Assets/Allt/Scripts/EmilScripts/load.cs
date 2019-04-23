using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{
    public bool gameEnd = false;
    public CheckpointEmil startAndFinish;
    
    

    private void Update()
    {
       



        if(startAndFinish.counter>=2)
        {
            gameEnd = true;
            //yield return new WaitForSeconds(3);
            endGame();
        }


    }


    public void buttonplip()
    {

        SceneManager.LoadScene(1);


    }
    public void loadMenuFromGO()
    {
        SceneManager.LoadScene(0);
    }

    public void endGame()
    {

        
        SceneManager.LoadScene(2);





        



    }
        



}
