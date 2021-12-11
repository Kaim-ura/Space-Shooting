using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationSpawn : MonoBehaviour
{
    public void Spawning()
    {
        float randomX, randomY;

        randomX = Random.Range(-9.5f, 9.5f);
        randomY = Random.Range(-4.45f, 4.45f);

        transform.position = new Vector3(randomX, randomY, 0f);
    }
}
    
