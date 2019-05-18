using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadMenu : MonoBehaviour
{
    private FileStream fS;
    private BinaryFormatter bF = new BinaryFormatter();
    public InputField input;
    public timeLoad getTime;
    private ClassB list = new ClassB();
  //  private ClassB counter = new ClassB();
    
    public string acro;

    private void Update()
    {
        acro = input.text;
    }
    public void loadMenuWithoutSaving()
    {
        PlayerPrefs.SetInt("save", 0);
        SceneManager.LoadScene(0);
        


    }

  public  void loadMenuAndSave()
    {
        PlayerPrefs.SetInt("save", 1);

        PlayerPrefs.SetString("name", acro);








        //selS(list, 11);


        if (File.Exists(Application.persistentDataPath + "HighScoreThree.dat"))
        {
            fS = File.Open(Application.persistentDataPath + "HighScoreThree.dat", FileMode.Open);


        }
        else
        {
            fS = File.Create(Application.persistentDataPath + "HighScoreThree.dat");
        }

        //counter = (ClassB)bF.Deserialize(fS);
       // list = (ClassB)bF.Deserialize(fS);



        /* for (int i = 0; i < 10; i++)
         {
             bF.Serialize(fS, list[i]);
         }
         */
        /* print(counter.counter);
         if (counter.counter == 0)
         {
             list.name[0] = acro;
             list.time[0] = getTime.timeToGive;
             list.counter = 1;

             bF.Serialize(fS, list);
         }
        else if(counter.counter > 0)
         {
             list.name[counter.counter] = acro;
             list.time[counter.counter] = getTime.timeToGive;
             list.counter = counter.counter + 1;

             bF.Serialize(fS, list);



         }

         */


        list.name[0] = acro;
        list.time[0] = getTime.timeToGive;
        list.counter = 1;

        bF.Serialize(fS, list);




        /*  while(fS!=null)
          {
              list[counter] = (ClassB)bF.Deserialize(fS);
              counter++;
          }
          */



        /*


        list[counter].name = acro;
        list[counter].time = getTime.timeToGive;


        if(counter>0)
        {
            selS(list, counter + 1);
        }

        if(counter+1<11)
        {
            for (int i = 0; i < counter + 1; i++)
            {
                bF.Serialize(fS, list[i]);
            }
        }
       else if(counter+1==11)
        {
            for (int i = 0; i < 10; i++)
            {
                bF.Serialize(fS, list[i]);
            }



        }

        */

        fS.Close();


        SceneManager.LoadScene(0);

    }

    /*
    private void selS(ClassB[] arr, int nrOf)
    {
        for(int i=0; i<nrOf-1; i++)
        {
            int smallest = i;

            for(int j=i+1; j<nrOf; j++ )
            {
                if(arr[j].time<arr[smallest].time)
                {
                    smallest = j;
                }



            }

            ClassB temp = arr[smallest];
            arr[smallest] = arr[i];
            arr[i] = temp;

        }




    }
    
    */

}
