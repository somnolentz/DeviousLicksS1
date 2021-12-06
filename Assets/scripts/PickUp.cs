using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    private bool triggered = false;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Player") && !triggered)
        {

            FindObjectOfType<ScoringSystem>().Increase();
            GetComponent<AudioSource>().Play();
            
            triggered = true;
            GetComponent<Renderer>().enabled = false;

            StartCoroutine(timedDestroy());

        }

    }
    
    IEnumerator timedDestroy()
    {

        yield return new WaitForSeconds(5);
        Destroy(gameObject);



    }

}
