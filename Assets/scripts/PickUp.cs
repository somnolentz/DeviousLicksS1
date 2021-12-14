using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    private bool triggered = false;

    public int abilityType; //0 = none , 1 = speedBoost , 2 = ??
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Player") && !triggered)
        {
            if (abilityType == 1)
            {
                collider.GetComponent<speedBoostAbility>().Activate();

            }
            else if (abilityType == 2)
            {

                collider.GetComponent<stunAbility>().Activate();
            }

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
