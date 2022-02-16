using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SingleChunkRandomizer : MonoBehaviour
{
    [SerializeField]
    private SingleChunkSpawner chunkSpawner;
    public Transform begin;
    public Transform end;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public GameObject[] waypoints;
    public GameObject[] triggers;
    public NavMeshSurface navMeshSurface;
    [SerializeField]
    GameObject[] nEVariantsMain;
    [SerializeField]
    GameObject[] nEVariantsDoor;
    [SerializeField]
    GameObject[] nWVariantsMain;
    [SerializeField]
    GameObject[] nWVariantsDoor;
    [SerializeField]
    GameObject[] sEVariantsMain;
    [SerializeField]
    GameObject[] sEVariantsDoor;
    [SerializeField]
    GameObject[] sWVariantsMain;
    [SerializeField]
    GameObject[] sWVariantsDoor;
    [SerializeField]
    GameObject[] upRoads;
    [SerializeField]
    GameObject[] downRoads;
    [SerializeField]
    GameObject[] leftRoads;
    [SerializeField]
    GameObject[] rightRoads;

    public bool processComplete = false;

    public bool firstChunk;

    public bool placementComplete;

    // Start is called before the first frame update
    void Start()
    {
        chunkSpawner = GameObject.FindGameObjectWithTag("ChunkSpawner").GetComponent<SingleChunkSpawner>();
        SetupRoads();
        RandomizeVariants();
        StartCoroutine(BuildNavigation());
        CompletionReport();
    }

    private void CompletionReport()
    {
        processComplete = true;
    }

    private IEnumerator BuildNavigation()
    {
        yield return new WaitForSeconds(0.2f);
        navMeshSurface.BuildNavMesh();
    }

    private void RandomizeVariants()
    {
        if (!firstChunk)
        {
            nWVariantsMain[Random.Range(0, nWVariantsMain.Length)].SetActive(true);
            nEVariantsMain[Random.Range(0, nEVariantsMain.Length)].SetActive(true);
            sWVariantsMain[Random.Range(0, sWVariantsMain.Length)].SetActive(true);
            sEVariantsMain[Random.Range(0, sEVariantsMain.Length)].SetActive(true);
            nWVariantsDoor[Random.Range(0, nWVariantsDoor.Length)].SetActive(true);
            nEVariantsDoor[Random.Range(0, nEVariantsDoor.Length)].SetActive(true);
            sWVariantsDoor[Random.Range(0, sWVariantsDoor.Length)].SetActive(true);
            sEVariantsDoor[Random.Range(0, sEVariantsDoor.Length)].SetActive(true);
        }            
    }

    private void SetupRoads()
    {
        if(!firstChunk)
        {
            //If prevoius chunk ends at right side
            if (chunkSpawner.spawnedChunks[chunkSpawner.spawnedChunks.Count - 2].end.position == chunkSpawner.spawnedChunks[chunkSpawner.spawnedChunks.Count - 2].right.position)
            {
                //Switch begin position to opposite
                Vector3 newBeginPosition = left.transform.position;
                begin.transform.position = newBeginPosition;
                //Activate appropriate waypoint
                waypoints[2].SetActive(true);
                triggers[2].SetActive(true);
                //Manage end position
                //Select random number
                int rand = Random.Range(0, 2);
                //Switch end position to random one, accordingly manage unused roads
                switch (rand)
                {
                    case 0:
                        end.transform.position = up.transform.position;
                        downRoads[0].SetActive(true);
                        downRoads[1].SetActive(false);
                        rightRoads[0].SetActive(true);
                        rightRoads[1].SetActive(false);
                        return;
                    case 1:
                        end.transform.position = down.transform.position;
                        upRoads[0].SetActive(true);
                        upRoads[1].SetActive(false);
                        rightRoads[0].SetActive(true);
                        rightRoads[1].SetActive(false);
                        return;
                }
            }
            //If prevoius chunk ends at up side
            if (chunkSpawner.spawnedChunks[chunkSpawner.spawnedChunks.Count - 2].end.position == chunkSpawner.spawnedChunks[chunkSpawner.spawnedChunks.Count - 2].up.position)
            {
                //Switch begin position to opposite
                Vector3 newBeginPosition = down.transform.position;
                begin.transform.position = newBeginPosition;
                //Activate appropriate waypoint
                waypoints[1].SetActive(true);
                triggers[1].SetActive(true);
                //Manage end position
                //Select random number
                int rand = Random.Range(0, 2);
                //Switch end position to random one, accordingly manage unused roads 
                switch (rand)
                {
                    
                    case 0:
                        end.transform.position = left.transform.position;
                        upRoads[0].SetActive(true);
                        upRoads[1].SetActive(false);
                        rightRoads[0].SetActive(true);
                        rightRoads[1].SetActive(false);
                        return;

                    case 1:
                        end.transform.position = right.transform.position;
                        leftRoads[0].SetActive(true);
                        leftRoads[1].SetActive(false);
                        upRoads[0].SetActive(true);
                        upRoads[1].SetActive(false);
                        return;
                }
            }

            //If prevoius chunk ends at down side
            if (chunkSpawner.spawnedChunks[chunkSpawner.spawnedChunks.Count - 2].end.position == chunkSpawner.spawnedChunks[chunkSpawner.spawnedChunks.Count - 2].down.position)
            {
                //Switch begin position to opposite
                Vector3 newBeginPosition = up.transform.position;
                begin.transform.position = newBeginPosition;
                //Activate appropriate waypoint
                waypoints[0].SetActive(true);
                triggers[0].SetActive(true);
                //Manage end position
                //Select random number
                int rand = Random.Range(0, 2);
                //Switch end position to random one, accordingly manage unused roads
                switch (rand)
                {
                    
                    case 0:
                        end.transform.position = left.transform.position;
                        downRoads[0].SetActive(true);
                        downRoads[1].SetActive(false);
                        rightRoads[0].SetActive(true);
                        rightRoads[1].SetActive(false);
                        return;
                    case 1:
                        end.transform.position = right.transform.position;
                        leftRoads[0].SetActive(true);
                        leftRoads[1].SetActive(false);
                        downRoads[0].SetActive(true);
                        downRoads[1].SetActive(false);
                        return;
                }
            }

            //If prevoius chunk ends at left side
            if (chunkSpawner.spawnedChunks[chunkSpawner.spawnedChunks.Count - 2].end.position == chunkSpawner.spawnedChunks[chunkSpawner.spawnedChunks.Count - 2].left.position)
            {
                //Switch begin position to opposite
                Vector3 newBeginPosition = right.transform.position;
                begin.transform.position = newBeginPosition;
                //Activate appropriate waypoint
                waypoints[3].SetActive(true);
                triggers[3].SetActive(true);
                //Manage end position
                //Select random number
                int rand = Random.Range(0, 2);
                //Switch end position to random one, accordingly manage unused roads
                switch (rand)
                {
                    case 0:
                        end.transform.position = up.transform.position;
                        leftRoads[0].SetActive(true);
                        leftRoads[1].SetActive(false);
                        downRoads[0].SetActive(true);
                        downRoads[1].SetActive(false);
                        return;
                    
                    case 1:
                        end.transform.position = down.transform.position;
                        leftRoads[0].SetActive(true);
                        leftRoads[1].SetActive(false);
                        upRoads[0].SetActive(true);
                        upRoads[1].SetActive(false);
                        return;                        
                }
            }           
        }        
    }
}
