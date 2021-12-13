using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public int theScore;
    public Countdowntimer timer;


    
    void Update()
    {
        scoreText.GetComponent<Text>().text = "SCORE:" + theScore;
        if (theScore == 6)
        {
            FindObjectOfType<gamemanager>().openPortal();


        }
    }
    public void Increase()
    {
        theScore++;


    }
}
