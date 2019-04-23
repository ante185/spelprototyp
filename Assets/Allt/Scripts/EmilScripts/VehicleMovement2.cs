using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement2 : MonoBehaviour {

    public float maxSpeed = 5; //Ideal maximum velocity, velocity will never equal maxSpeed on it's own
    public float reverseFactor = 1; //faktor that limits reverse speed, 0.5 equals a max reverse speed of half maxSpeed
    public float acceleration = 0.5f;
    public float deacceleration = 0.05f;
    public float breakForce = 1.0f;
    public float turnrate = 50f;
    private float velocity = 0; //keeps track of current speed

    

    public Display pickUps;
    private GameMaster gm;
    private float delay = 5.0f;
    private const int nrOf = 50;
    private float[] itemTime = new float[nrOf];
    private GameObject[] item = new GameObject[nrOf];
    private bool[] timeIncrease = new bool[nrOf];
    private int counter = 0;
    private int health = 1000;
    private bool[] speedIncr = new bool[nrOf];
    private bool[] speedredu = new bool[nrOf];
    private int reduceCounter = 0;
    private int boostCounter = 0;
    private float[] boostTimer = new float[nrOf];
    private float[] reduceTimer = new float[nrOf];
    private GameObject[] boostItem = new GameObject[nrOf];
    private GameObject[] reduceItem = new GameObject[nrOf];
    

    // Use this for initialization
    void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckpointPos;

        
}


    public void updateVelocity(float deltaV)
    {
        this.velocity += deltaV * Time.deltaTime;
    }
    public void setVelocity(float V)
    {
        this.velocity = V;
    }
    void turn()
    {
        if (Input.GetKey("d"))
        {
            this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), turnrate * Time.deltaTime * (velocity / maxSpeed));
        }
        if (Input.GetKey("a"))
        {
            this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), -turnrate * Time.deltaTime * (velocity / maxSpeed));
        }
    }

    void movement()
    {

        if (Input.GetKey("w"))
        {
            if (velocity < 0)
            {
                updateVelocity(breakForce - breakForce * (velocity / maxSpeed));
            }
            else if (velocity < maxSpeed)
            {
                updateVelocity(acceleration - acceleration * (velocity / maxSpeed));
            }
            else
            {
                velocity = maxSpeed;
            }
        }
        else if (Input.GetKey("s"))
        {
            if (velocity > 0)
            {
                updateVelocity(-breakForce - breakForce * (velocity / maxSpeed));
            }
            else if (velocity > -maxSpeed * reverseFactor)
            {
                updateVelocity(-acceleration - acceleration * (velocity / (maxSpeed * reverseFactor)));
            }
            else
            {
                velocity = -maxSpeed * reverseFactor;
            }
        }
        else
        {
            velocity += -velocity * deacceleration * Time.deltaTime;
            if (System.Math.Abs(velocity) < 0.1)
            {
                velocity = 0;
            }
        }

        this.transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }




    
    void FixedUpdate ()
    {
        turn();
        movement();
        print(velocity);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Spelaren hamnar på samma plats och samma riktning som den senaste checkpointen
            transform.position = gm.lastCheckpointPos;
            transform.rotation = gm.lastCheckpointRot;
        }




        for (int i = 0; i< boostCounter; i++)
        {
            if (speedIncr[i])
            {
                boostTimer[i] += Time.deltaTime;
                if (boostTimer[i] > delay)
                {


                    boostItem[i].SetActive(true);





                    velocity -= 2;
                    boostTimer[i] = 0.0f;
                    speedIncr[i] = false;
                }

            }




        }

        for(int k=0; k<reduceCounter; k++)
        {

            if (speedredu[k])
            {
                reduceTimer[k] += Time.deltaTime;

                if (reduceTimer[k] > delay)
                {


                    reduceItem[k].SetActive(true);





                    maxSpeed += 2.5f;
                    reduceTimer[k] = 0.0f;
                    speedredu[k] = false;

                }



            }




        }


        for (int j = 0; j < counter; j++)
        {

            if (timeIncrease[j])
            {
                itemTime[j] += Time.deltaTime;

                if (itemTime[j] > delay)
                {


                    item[j].SetActive(true);



                    itemTime[j] = 0.0f;
                    timeIncrease[j] = false;
                    
                }

            }


           
          




        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("timeReduction"))
        {


            if (item[counter] != other.gameObject)
            {
                item[counter] = other.gameObject;
                timeIncrease[counter] = true;
                counter += 1;




            }




            other.gameObject.SetActive(false);
            pickUps.addTime();
        }

        if(other.gameObject.CompareTag("SpeedBoost"))
        {

            if (boostItem[boostCounter] != other.gameObject)
            {
                boostItem[boostCounter] = other.gameObject;
                speedIncr[counter] = true;
                boostCounter += 1;




            }

            

            other.gameObject.SetActive(false);
            increaseSpeed();
        }

        if (other.gameObject.CompareTag("SpeedReduction"))
        {

            if (reduceItem[reduceCounter] != other.gameObject)
            {
                reduceItem[reduceCounter] = other.gameObject;
                speedredu[counter] = true;
                reduceCounter += 1;




            }



            other.gameObject.SetActive(false);
            reduceSpeed();
        }




    }



    private void reduceSpeed()
    {
        
        maxSpeed -= 2.5f;
    }

    private void increaseSpeed()
    {
        velocity += 2;

    }

    public float getcurrentSpeed()
    {
        return velocity;
    }
        
        


}
