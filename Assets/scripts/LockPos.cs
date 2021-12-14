using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPos : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.transform.position;
      
    }
    
}
