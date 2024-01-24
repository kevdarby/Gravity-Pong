using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BallPhysics : MonoBehaviour
{
    public Vector3 velocity;
    public float startingVelSign = 1;
    float relativeIntersectY;
    float bounceAngle;

    static int player1Score;
    static int player2Score;

    public TMP_Text score1;
    public TMP_Text score2;

    public GameObject planet;
    float fg;
    private float G = 0.02f; // Force of gravity, approximately 0.02 was found to be the best.
    Vector3 fgnorm;
    float radius;
    void Start()
    {
         velocity = new Vector3(-.23f * startingVelSign, Random.Range(-.1f,.1f), 0f);
         
    }
    
    void FixedUpdate()
    {
        // physics calculations that are calculated a fixed amounnt time per second
        transform.position = transform.position + velocity;
        
        radius = Mathf.Max(Vector3.Distance(planet.GetComponent<Transform>().position, transform.position), .4f);
        
        Vector3 radiusnorm = (planet.GetComponent<Transform>().position - transform.position).normalized;

        // simplified newtons law of Gravitivy: Fg = GMm/r^2, however the masses were assumed to be 1. After testing diving by r instead of r^2 led to more engaging matches
        fg = G / radius; 
        fgnorm = fg * radiusnorm; // when multiplying by the radius norm, you point the Force in the right direction. F(vector) = F(magnitude) * V(unit vector pointing between the 2 balls)

        velocity = velocity + fgnorm;
    
    }
    private void OnTriggerEnter(Collider other)
    {   
        if(other.tag=="Player")
        {
            // Bounce off player   
            relativeIntersectY = (transform.position.y - other.GetComponent<Transform>().position.y);
            bounceAngle = relativeIntersectY* 1.309f;
            velocity.x = -velocity.x*1.03f;
            
            //velocity.x = -Mathf.Sign(velocity.x)*velocity.magnitude*Mathf.Cos(bounceAngle);
            velocity.y = velocity.magnitude*Mathf.Sin(bounceAngle);
        }
        if(other.tag=="Boundary")
        {
            // bounce off top and bottom
            velocity.y = -velocity.y;
        }
        if(other.tag=="Player1Boundary")
        {
            // hit player 1 wall
            transform.position = new Vector3(0f,0f,0f);
            velocity = new Vector3(.15f, Random.Range(-.1f,.1f), 0f);
            player2Score += 1;
            
            score2.text = player2Score.ToString();
        }
        if(other.tag=="Player2Boundary")
        {
            // hit player 2 wall
            transform.position = new Vector3(0f,0f,0f);
            velocity = new Vector3(-.15f, Random.Range(-.1f,.1f), 0f);
            player1Score += 1;
           
            score1.text = player1Score.ToString();
        }
    }
}
