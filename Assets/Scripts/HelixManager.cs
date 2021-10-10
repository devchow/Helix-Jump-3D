using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn = 0;
    public float ringDistance = 5f;

    public int numberOfRings;

    private void Start()
    {
        // Adding Number of Rings as Level Progresses
        numberOfRings = GameManager.currentLevelIndex + 5;

        // Spawning the Helix + Rings
        for (int i = 0; i < numberOfRings; i++)
        {
            // Ensuring the Safe ring is Spawned First
            if(i == 0)
            {
                SpawnRing(0);
            } 
            else // Spawning the other Rings
            {
                SpawnRing(Random.Range(1, helixRings.Length - 1));
            }
            
        }

        // Spawning the Last Ring
        SpawnRing(helixRings.Length - 1);
    }

    public void SpawnRing(int ringIndex)
    {
        GameObject go = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        go.transform.parent = transform;
        ySpawn -= 5;
    }
}
