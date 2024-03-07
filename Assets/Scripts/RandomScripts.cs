using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomScripts : MonoBehaviour
{
    public GameObject enemy, teleportLocation;
  

    public void Start()
    {
        
    }

    public void TeleportEnemy(GameObject targetLocation)
    {
        teleportLocation = targetLocation;

        enemy.transform.position = targetLocation.transform.position;
    }
}
