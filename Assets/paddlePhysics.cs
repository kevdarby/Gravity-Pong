using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddlePhysics : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 velocity = new Vector3(0.0f, 0f,0.0f);
    public GameObject childPaddle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       this.transform.position += velocity;  
       
    }

}
