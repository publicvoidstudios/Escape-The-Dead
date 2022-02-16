using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    List<Transform> spawnPoints;
    [SerializeField]
    GameObject enemiesPrefab;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        int activePointsAmount = Random.Range(2, spawnPoints.Count);
        for (int i = 0; i < activePointsAmount; i++)
        {
            int chosenPoint = Random.Range(0, spawnPoints.Count - 1);
            int spawnChance = Random.Range(0, 3);
            if(spawnChance == 1 || spawnChance == 2)
            {
                GameObject enemy = Instantiate(enemiesPrefab, spawnPoints[chosenPoint].position, Quaternion.Euler(0, Random.Range(0, 360), 0));
                enemy.transform.parent = spawnPoints[chosenPoint];
                enemy.name += "@" + spawnPoints[chosenPoint].name + " seed: " + Random.Range(1, 1000);
                spawnPoints.RemoveAt(chosenPoint);
            }
            else
            {
                spawnPoints.RemoveAt(chosenPoint);
            }
        }
    }
}
