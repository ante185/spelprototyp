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
    private float fixedMaxSpeed; //this value is used to reset the maxspeed variable, shall not be changed.

    private GameMasterEmil gm;
    
    // Use this for initialization
    void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMasterEmil>();
        transform.position = gm.lastCheckpointPos;
        fixedMaxSpeed = maxSpeed;
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
        //print(velocity);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Spelaren hamnar på samma plats och samma riktning som den senaste checkpointen
            transform.position = gm.lastCheckpointPos;
            transform.rotation = gm.lastCheckpointRot;
        }
    }

    public void setMaxSpeed(float newSpeed)
    {
        maxSpeed = newSpeed;
    }
    public void addMaxSpeed(float delteSpeed)
    {
        maxSpeed += delteSpeed;
    }
    public void resetMaxSpeed()
    {
        maxSpeed = fixedMaxSpeed;
    }

    public float getMaxSpeed()
    {
        return maxSpeed;
    }
    public float getfixedMaxSpeed()
    {
        //this value is used to reset the maxspeed variable
        return fixedMaxSpeed;
    }

    public void updateVelocity(float deltaV)
    {
        this.velocity += deltaV * Time.deltaTime;
    }
    public void setVelocity(float V)
    {
        this.velocity = V;
    }


    public void decreaseSpeed()
    {
        //Använd updateVelocity istället
        updateVelocity(-2);




    }


    public void increaseSpeed()
    {
        //Använd updateVelocity istället
        updateVelocity(2);




    }

    public float getcurrentSpeed()
    {
        return velocity;
    }
        
  


}
