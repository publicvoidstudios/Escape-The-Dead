using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] treePrefabs;

    [SerializeField]
    GameObject[] grassPrefabs;

    [SerializeField]
    int grassIterations;

    [SerializeField]
    Transform[] spawnSpots;

    [SerializeField, Range(0.1f, 1f)]
    float invokationDelay;
    Vector3 offset;

    void OnEnable()
    {
        Invoke("Iterate", invokationDelay);
    }

    private void Iterate()
    {
        for(int i = 0; i < spawnSpots.Length; i++)
        {
            SpawnTree(i);
            SpawnGrass(i, grassIterations);
        }
    }

    private void SpawnTree(int iteration)
    {
        offset = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        GameObject tree = Instantiate(treePrefabs[Random.Range(0, treePrefabs.Length)], spawnSpots[iteration].position + offset, Quaternion.Euler(0, Random.Range(0, 360), 0));
        tree.transform.parent = spawnSpots[iteration];
    }
    private void SpawnGrass(int iteration, int cycles)
    {
        for(int i = 0; i < cycles; i++)
        {
            offset = new Vector3(Random.Range(-1f, 1f), 0.1f, Random.Range(-1f, 1f));
            GameObject grass = Instantiate(grassPrefabs[Random.Range(0, grassPrefabs.Length)], spawnSpots[iteration].position + offset, Quaternion.Euler(0, Random.Range(0, 360), 0));
            grass.transform.parent = spawnSpots[iteration];
        }
    }
}
