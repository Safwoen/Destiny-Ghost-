using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npcpath : MonoBehaviour
{
    public Transform path1;
    public Transform path2;
    public Transform path3;
    public Transform path4;
    public Transform npc;
    
    public int pathPoint;
    public float speed;


    // Update is called once per frame
    void Update()
    {
        if(pathPoint == 0)
        {
            npc.position = Vector3.MoveTowards(npc.position, path1.position, speed);
        }
        if (pathPoint == 1)
        {
            npc.position = Vector3.MoveTowards(npc.position, path2.position, speed);
        }
        if (pathPoint == 2)
        {
            npc.position = Vector3.MoveTowards(npc.position, path3.position, speed);
        }
        if (pathPoint == 3)
        {
            npc.position = Vector3.MoveTowards(npc.position, path4.position, speed);
        }
        if (pathPoint == 4)
        {
            pathPoint = pathPoint - 5;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Path")
        {
            pathPoint++;
        }
    }
}
