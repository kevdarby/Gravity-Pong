using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
   // script to pause the game and move player 1's wall
   Vector3 velocity;
   bool isPause = false;
    void Update()
    {
       if (Input.GetKey("w"))
        {
           velocity = new Vector3(0f, .12f, 0f);
           
        }
        else if (Input.GetKey("s"))
        {
           velocity = new Vector3(0f, -.12f, 0f);
        }
        else{
            velocity = new Vector3(0f,0f,0f);
        }

        if(Input.GetKeyDown("escape"))
        {
         if(isPause)
         {
            Debug.Log("PAUSE");
            Time.timeScale = 1;
            isPause = false;
         }
         else if(isPause == false)
         {
            Debug.Log("PAUSE");
            Time.timeScale = 0;
            isPause = true;
         }
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
