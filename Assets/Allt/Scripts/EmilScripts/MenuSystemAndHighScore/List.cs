using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class List : MonoBehaviour
{
    private FileStream fS;
    private BinaryFormatter bF = new BinaryFormatter();
    
    private ClassB blabla = new ClassB();
    //private int counter = 0;
    public Text text;
    private string complete;

void Start()
    {
        if (File.Exists(Application.persistentDataPath + "HighScoreThree.dat"))
        {
            fS = File.Open(Application.persistentDataPath + "HighScoreThree.dat", FileMode.Open);

            /*
            for(int i=0; i<10; i++)
            {
                lists[i] = (ClassB)bF.Deserialize(fS);
            }
            */
            /* while (fS != null)
             {
                 lists[counter] = (ClassB)bF.Deserialize(fS);
                 counter++;
             }
             */
            /*for(int i=0; i<10; i++)
            {
                complete = complete + lists[i].name + "   " + lists[i].time.ToString() + "\n\n"; 



            }

            text.text = complete;
            */

            blabla = (ClassB)bF.Deserialize(fS);



            complete = blabla.name[0] + "  " + blabla.time[0].ToString() + "\n\n";

            for(int i=1; i<blabla.counter; i++)
            {
                complete = complete + blabla.name[i] + "  " + blabla.time[i].ToString() + "\n\n";
            }



            text.text = complete;

            fS.Close();


        }
    }
     

}
