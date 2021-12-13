using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum AbilityType
{
    None=0,
    SpeedBoost=1,
    Stun=2
}
public class PickUp : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Player") && !triggered)
        {
            this.GetComponent<IAbility>().Activate();
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
