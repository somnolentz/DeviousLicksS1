using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculation : MonoBehaviour
{

    public GameObject ScoreDisplay;
    public ScoringSystem scoreSystem;
    public Countdowntimer countdownTimer;                       
    

    public void score()
    {
        int total = scoreSystem.theScore * (int)countdownTimer.currentTime;

        ScoreDisplay.GetComponent<Text>().text = ""+ total ;



    }













}
