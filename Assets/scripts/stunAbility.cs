using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunAbility : MonoBehaviour
{
    public float stunTime = 5;
    public float stunTimer = 0;
    public float stunRadias = 10;
    private List<GameObject> affectedGuards;

    public bool isStun = false;
    
    void Start()
    {
        

    }

    
    void Update()
    {
        if (isStun)
        {
            stunTimer += Time.deltaTime;
            if(stunTimer >= stunTime)
            {
                Destun();
            }
        }

    }
    public void Activate()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, stunRadias); //Issue starts here
        Debug.Log("found: " + hitColliders.Length);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag.Equals("Guard"))
            {
                if (hitCollider.gameObject.GetComponent<Guard>() != null)
                    affectedGuards.Add(hitCollider.gameObject);
            }
        }
        
        Stun();
    }
    void Stun()
    {
        isStun = true;
        if (affectedGuards.Count != 0)
        {

            foreach (var guard in affectedGuards)
            {
                //guard.enabled = false;
                guard.GetComponent<Renderer>().material.color = Color.cyan;
            }


        }
           
    }
    void Destun()
    {
        
        isStun = false;
        stunTimer = 0;
        if (affectedGuards.Count != 0)
        {

            foreach (var guard in affectedGuards)
            {
                //guard.enabled = true;
                guard.GetComponent<Renderer>().material.color = Color.white;
            }


        }
        affectedGuards.Clear();

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, stunRadias);

    }
}


