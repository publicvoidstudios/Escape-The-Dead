using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleChunkSpawner : MonoBehaviour
{
    public Transform player;
    public SingleChunkRandomizer ChunkPrefab;
    public SingleChunkRandomizer firstChunk;
    [SerializeField, Range(3, 6)]
    int chunkLimit = 3;

    public List<SingleChunkRandomizer> spawnedChunks = new List<SingleChunkRandomizer>();

    private Vector3 offset = new Vector3(0, -100, 0);

    private void Start()
    {
        //StartCoroutine(SpawnChunk());
    }

    private void RemoveOldNavMeshes()
    {
        for (int i = 0; i < spawnedChunks.Count - 1; i++)
        {
            Destroy(spawnedChunks[i].navMeshSurface);
        }
    }
    public IEnumerator SpawnChunk()
    {
        if(spawnedChunks[spawnedChunks.Count - 1].processComplete)
        {
            SingleChunkRandomizer newChunk = Instantiate(ChunkPrefab, Vector3.zero + offset, Quaternion.identity);
            spawnedChunks.Add(newChunk);
            yield return new WaitForSeconds(0.1f);
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 2].end.position - newChunk.begin.localPosition;
            newChunk.placementComplete = true;

            if (spawnedChunks.Count >= chunkLimit)
            {
                Destroy(spawnedChunks[0].gameObject);
                spawnedChunks.RemoveAt(0);
            }
            RemoveOldNavMeshes();
        }        
    }
}
