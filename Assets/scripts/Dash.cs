using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float dashSpeed;
    [SerializeField] public float dashTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Dashmovement());
            
        }
    }

    IEnumerator Dashmovement()
    {
        float startTime = Time.time;
        while (Time.time < startTime + dashTime)
        {
            transform.Translate(Vector3.forward * dashSpeed);

            yield return null;
        }

    }


}
