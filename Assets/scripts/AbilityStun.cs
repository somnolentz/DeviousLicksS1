using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityStun : MonoBehaviour,IAbility
{
    public float stunTime = 5;
    public float stunTimer = 0;
    public float stunRadias = 10;
    private List<Guard> affectedGuards;
    [SerializeField]private LayerMask mask;

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
        stunTimer = 0;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, stunRadias, mask); //Issue starts here
        Debug.Log("found: " + hitColliders.Length);
        affectedGuards = new List<Guard>();
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag.Equals("Guard"))
            {
                affectedGuards.Add(hitCollider.gameObject.GetComponent<Guard>());
            }
        }
        Debug.Log("<color=red>"+affectedGuards.Count+"</color>");
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

    public void Deactivate()
    {
        throw new System.NotImplementedException();
    }
}


public interface IAbility
{
    void Activate();
    void Deactivate();
}