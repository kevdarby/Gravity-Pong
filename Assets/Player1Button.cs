using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Button : MonoBehaviour
{
    public GameObject ball1;
    public GameObject ball2;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject button1;
    public GameObject button2;
    public GameObject text;
   public void OnButtonPress1(){
      // Activated when "1 Player" is selected

      ball1.GetComponent<BallPhysics>().enabled = true;
      ball2.GetComponent<BallPhysics>().enabled = true;
      Player1.GetComponent<Player1Controller>().enabled = true;
      Player2.GetComponent<ComputerController>().enabled = true;

      button1.SetActive(false);
      button2.SetActive(false);
      text.SetActive(false);        
   }
   public void OnButtonPress2(){
      // Activated when "2 Player" is selected
      
      ball1.GetComponent<BallPhysics>().enabled = true;
      ball2.GetComponent<BallPhysics>().enabled = true;
      Player1.GetComponent<Player1Controller>().enabled = true;
      Player2.GetComponent<Player2Controller>().enabled = true;

      button1.SetActive(false);
      button2.SetActive(false);
      text.SetActive(false);
      
    
   }
}
