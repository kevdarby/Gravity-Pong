using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    // Activated when "Player 1" button is selected
    // A simple script that calcualtes the closest ball to the computer player's wall and adjusts its velocity to either go up or down accordingly.
    public GameObject ball1;
    public GameObject ball2;
    GameObject ball;
    Vector3 velocity;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(ball1.GetComponent<Transform>().position.x > ball2.GetComponent<Transform>().position.x)
        {
            ball = ball1;
        }
        else
        {
            ball = ball2;
        }
        if(ball.GetComponent<BallPhysics>().velocity.x > 0 && Mathf.Abs(ball.GetComponent<Transform>().position.y - transform.position.y) > 1)
        {
            if(ball.GetComponent<Transform>().position.y > transform.position.y)
            {
                velocity = new Vector3(0f, .12f, 0f);
            }
            if(ball.GetComponent<Transform>().position.y < transform.position.y)
            {
                velocity = new Vector3(0f, -.12f, 0f);
            }
            transform.position = transform.position + velocity;
            
        }
       
    }
}
