using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject endscreen;
    private void Start()
    {
        endscreen.SetActive(false);



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {

            endscreen.GetComponent<ScoreCalculation>().score();
            endscreen.SetActive(true);
            Time.timeScale = 0;

        }
       

    }


}
