using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSystem : MonoBehaviour
{
    public Vector3 Offset;
    public GameObject[] prefabs;
    public Transform[] locations;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {
        foreach (Transform point in locations)
        {
            int index = Random.Range(0, prefabs.Length);
            var pos = point.position;
            pos.x += Offset.x;
            pos.y += Offset.y;
            pos.z += Offset.z;
            GameObject item = Instantiate(prefabs[index], pos, point.rotation) as GameObject;
        }

    }
}
