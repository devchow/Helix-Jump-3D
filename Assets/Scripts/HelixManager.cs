using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn = 0;
    public float ringDistance = 5f;

    public int numberOfRings = 7;

    private void Start()
    {
        // Spawning the Helix + Rings
        for(int i = 0; i < numberOfRings; i++)
        {
            SpawnRing(Random.Range(0, helixRings.Length));
        }
    }

    public void SpawnRing(int ringIndex)
    {
        GameObject go = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        go.transform.parent = transform;
        ySpawn -= 5;
    }
}
