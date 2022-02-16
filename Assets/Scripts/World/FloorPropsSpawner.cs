using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPropsSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] floorPropsPrefabs;
    [SerializeField]
    Transform[] spawnPoints;

    [SerializeField]
    int iterations;

    [SerializeField, Range(0.1f, 1f)]
    float invokationDelay;

    [SerializeField, Range(0.5f, 5f)]
    float offsetValue;


    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Iterate", invokationDelay);
    }

    private void Iterate()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            SpawnPrefab(i, iterations);
        }
    }

    private void SpawnPrefab(int iteration, int cycles)
    {
        for (int i = 0; i < cycles; i++)
        {
            offset = new Vector3(Random.Range(-offsetValue, offsetValue), 0.1f, Random.Range(-offsetValue, offsetValue));
            GameObject prop =  Instantiate(floorPropsPrefabs[Random.Range(0, floorPropsPrefabs.Length)], spawnPoints[iteration].position + offset, Quaternion.Euler(0, Random.Range(0, 360), 0));
            prop.transform.parent = spawnPoints[iteration];
        }
    }
}
