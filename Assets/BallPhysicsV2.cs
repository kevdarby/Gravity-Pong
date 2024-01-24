using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysicsV2 : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0.0f, 0.03f, -0.09f);
    Vector3 gravity = new Vector3(0f, -.0010f, 0f);
    Vector3 force;
    Vector3 paddleDirection;
    float time = .1f;
    float forceScalar;
    public GameObject table;
    public GameObject paddleParent;
    float airResistenceMag = 0.0005f;
    public GameObject otherBall;
    void FixedUpdate()
    {
        velocity += force;
        this.transform.position += velocity;
        velocity += gravity;   
        velocity -= velocity * airResistenceMag;
        // energy test Debug.Log(200* ( velocity.magnitude * velocity.magnitude + .001 * (transform.position.y - .25)));

        velocity += Mathf.Abs((0.00005f / Vector3.Distance(transform.position, otherBall.transform.position))) * (otherBall.transform.position -this.transform.position).normalized;
       
        
    }
    // table bounce
    private void OnTriggerEnter(Collider collision)
    {
        
        velocity -= velocity * airResistenceMag * 3;
        
        if (collision.gameObject.name == "Table")
        {
            velocity = Reflection(velocity, table.transform.forward);   
        }


        if (collision.gameObject.name == "PaddleHead")
        {
            paddleParent = collision.gameObject.transform.parent.gameObject;
            // Debug.Log("Velocity before: " + velocity);  
            paddleDirection = paddleParent.transform.forward;
            if(Vector3.Dot(paddleDirection, velocity) > 0)
            {
                paddleDirection *= -1;
            }
            // Debug.Log("Direction " + paddleDirection);
            forceScalar =  Mathf.Abs(Time.fixedDeltaTime *  (2 * Mathf.Abs(Vector3.Dot(velocity, paddleParent.GetComponent<paddlePhysics>().transform.forward)) + Vector3.Dot(paddleParent.GetComponent<paddlePhysics>().velocity, paddleParent.GetComponent<paddlePhysics>().transform.forward )) / (time ));
            // Debug.Log("Scalar" + forceScalar);
            force = forceScalar * paddleDirection;
            // Debug.Log("Direction " + paddleDirection);
            // Debug.Log("force " + force);
            Invoke("turnOffForce", time);
        }
        
    }

    public Vector3 Reflection(Vector3 ball, Vector3 paddle)
    {
        return ball - (2 * ((Vector3.Dot(ball,paddle)) * paddle));     
    }
    
    private void turnOffForce()
    {
        force = new Vector3(0f, 0f, 0f);
    }
    

    
    
}
