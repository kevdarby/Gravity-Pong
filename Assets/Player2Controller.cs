using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    // similar to Player1Controller, called when "2 Player" is selected, uses arrow keys instead of w and s. 
    Vector3 velocity;
    
    void Update()
    {
       if (Input.GetKey("up"))
        {
           velocity = new Vector3(0f, .12f, 0f);
           
        }
        else if (Input.GetKey("down"))
        {
           velocity = new Vector3(0f, -.12f, 0f);
           
        }
        else{
            velocity = new Vector3(0f,0f,0f);
        }
    }
    void FixedUpdate()
    {
        transform.position = (transform.position + velocity);

        if(transform.position.y <= -3.5f)
       {
        transform.position = new Vector3(transform.position.x, -3.5f, 0f);
       }
       if(transform.position.y >= 3.5f)
       {
        transform.position = new Vector3(transform.position.x, 3.5f, 0f);
       }
    }
}
