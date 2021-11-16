using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topDownCam : MonoBehaviour
{
    public Transform player;

    public float smooth = 0.3f;

    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.position;
        pos.x += offset.x;
        pos.z += offset.z;
        pos.y += offset.y;


        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
    }
}
