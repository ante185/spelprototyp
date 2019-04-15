using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class carClass : MonoBehaviour {

    public Display pickUps;
    public float moveSpeed = 2f;
    public float turnSpeed = 10f;
    public float rotationAngle = 10.0f;
    public float rotationAngleTwo = -10.0f;

    private GameMaster gm;
    private float delay = 5.0f;
    private const int nrOf = 50;
    private float[] itemTime = new float[nrOf];
    GameObject[] item = new GameObject[nrOf];
    private bool[] timeIncrease = new bool[nrOf];
    private int counter = 0;
    private int health = 1000;



    //private float currentRotation;
    // private Quaternion blabla;  


    // public Quaternion getRotation()
    //{


    //  return blabla;
    //}


    // Use this for initialization
    void Start () {

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckpointPos;


    }
	
	// Update is called once per frame
	void Update () {

        // blabla = gameObject.transform.rotation;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            transform.position = gm.lastCheckpointPos;
            transform.rotation = gm.lastCheckpointRot;
        }



        for (int j=0; j<counter; j++)
        {

            if (timeIncrease[j])
            {
                itemTime[j] += Time.deltaTime;

                if (itemTime[j] > delay)
                {

                    
                        item[j].SetActive(true);
                    



                    timeIncrease[j] = false;
                    itemTime[j] = 0.0f;
                }

            }


        }

      

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate(Vector3.right * turnSpeed * Time.deltaTime);

           transform.Rotate(0.0f, rotationAngleTwo , 0.0f);
            
            //currentRotation = rotationAngle;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.Translate(Vector3.left * turnSpeed * Time.deltaTime);

            transform.Rotate(0.0f, rotationAngle, 0.0f);

          //  currentRotation = rotationAngleTwo;
        }
      

	}

   


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("timeReduction"))
        {
            
            
                if(item[counter] != other.gameObject)
                {
                    item[counter] = other.gameObject;
                    timeIncrease[counter] = true;
                    counter += 1;




                }


            

            other.gameObject.SetActive(false);
            pickUps.addTime();
        }







    }

  


    


}
