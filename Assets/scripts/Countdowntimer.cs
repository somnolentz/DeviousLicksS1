using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdowntimer : MonoBehaviour
{
   public float currentTime = 0f;
    public float startingTime = 180f;
    public float timeLeft;
    public Text countdownText;
    public gamemanager gameManager;

    void Start()
    {
       currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        

        if (currentTime <=0)
        {

            currentTime = 0;
            Debug.Log("fuck");
            gameManager.gameOver();
           
        }
        countdownText.text = currentTime.ToString("0");

    }
    public void Deduct(float time)
    {
        currentTime -= time * Time.deltaTime;
    }
   
    

}
