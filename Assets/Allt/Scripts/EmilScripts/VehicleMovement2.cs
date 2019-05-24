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

    public float rotationLerpFac;

    public Vector3 speed;
    

    private float velocity = 0; //keeps track of current speed
    private float fixedMaxSpeed; //this value is used to reset the maxspeed variable, shall not be changed.
    private float slowDown;
    
    private Quaternion targetRotation;
    private Rigidbody rb;

    public allSound sound;

    
    // Use this for initialization
    void Start ()
    {
        fixedMaxSpeed = maxSpeed;
        InvokeRepeating("resetMaxSpeed", 1f, 1f);
        rb = GetComponent<Rigidbody>();
    }
    void turn()
    {
        if (Input.GetKey("d"))
        {
            this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), 2 + turnrate * Time.deltaTime * (velocity / maxSpeed));
        }
        if (Input.GetKey("a"))
        {
            this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), -2 + -turnrate * Time.deltaTime * (velocity / maxSpeed));
        }
    }

    void movement()
    {

        if (Input.GetKey("w") && velocity < maxSpeed)
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
        else if (Input.GetKey("s") && velocity > -maxSpeed * reverseFactor)
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
        if(speed[2] < velocity && velocity != 0)
        {
            rb.AddForce(transform.forward * acceleration * 5);
        }
        else if (speed[2] > velocity && velocity != 0)
        {
            rb.AddForce(-transform.forward * acceleration * 5);
        }
        
    }




    
    void FixedUpdate ()
    {
        turn();
        movement();

        Matrix4x4 toLocal = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        speed = toLocal.MultiplyVector(rb.velocity);

        targetRotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, transform.rotation.z / 10);
    }


    private void Update()
    {
        
        


        if (velocity>=0 && velocity<=10)
        {
            if (sound.source.isPlaying == false)
            {
                sound.source.PlayOneShot(sound.engineStart);
            }
        }
        if(velocity<0)
        {
            if (sound.source.isPlaying == false)
            {
                sound.source.PlayOneShot(sound.reverse);
            }

        }

        if(velocity>10)
        {
            if (sound.source.isPlaying == false)
            {
                sound.source.PlayOneShot(sound.forward);
            }
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
        maxSpeed -= 2;

        if (maxSpeed < fixedMaxSpeed)
        {
            maxSpeed = fixedMaxSpeed;
        }
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

    public float getcurrentSpeed()
    {
        return velocity;
    }
        
  


}
