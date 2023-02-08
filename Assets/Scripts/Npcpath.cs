using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npcpath : MonoBehaviour
{
    public Transform npc;

    public Transform[] path;
    
    public int pathPoint;
    public float speed;


    // Update is called once per frame
    void Update()
    {
        npc.position = Vector3.MoveTowards(npc.position, path[pathPoint].position, speed);
        Vector3 newDir = (new Vector3(path[pathPoint].position.x, 0, path[pathPoint].position.z) - new Vector3(npc.position.x, 0, npc.position.z));

        transform.forward = newDir;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Path")
        {
            pathPoint++;

            if (pathPoint > 4)
            {
                pathPoint = 0;
            }
        }
    }
}
