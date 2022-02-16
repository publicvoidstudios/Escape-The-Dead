using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChunkSpawner : MonoBehaviour
{
    private SingleChunkSpawner chunkSpawner;

    void Start()
    {
        chunkSpawner = GameObject.FindGameObjectWithTag("ChunkSpawner").GetComponent<SingleChunkSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chunkSpawner.StartCoroutine(chunkSpawner.SpawnChunk());
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
