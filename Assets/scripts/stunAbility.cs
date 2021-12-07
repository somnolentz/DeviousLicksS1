using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunAbility : MonoBehaviour
{
    public float stunTime = 5;
    public float stunTimer = 0;
    public float stunRadias = 10;
    private List<Guard> affectedGuards;

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

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, stunRadias, 10); //Issue starts here
        Debug.Log("found: " + hitColliders.Length);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag.Equals("Guard"))
            {
                affectedGuards.Add(hitCollider.gameObject.GetComponent<Guard>());
            }
        }
        Stun();
    }
    void Stun()
    {
        isStun = true;
        foreach(var guard in affectedGuards)
        {
            guard.enabled = false;
        }
    }
    void Destun()
    {
        isStun = false;
        stunTimer = 0;
        foreach (var guard in affectedGuards)
        {
            guard.enabled = true;
        }
    }
}


