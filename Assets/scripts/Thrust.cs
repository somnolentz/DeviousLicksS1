using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : MonoBehaviour
{
    public float dash;
    private Rigidbody rb;
    public float velocity = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

         
           

            rb.AddForce((transform.forward * 1) * dash, ForceMode.VelocityChange);
           
        }
    }
}
