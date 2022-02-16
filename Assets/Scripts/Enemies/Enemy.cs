using System.Collections;
using UnityEngine;
using UnityEngine.AI;
//Класс для врагов
public class Enemy : MonoBehaviour
{
    [SerializeField]
    PlayerProgress player;
    [SerializeField]
    AudioManager audioManager;
    LevelCompleteCheck levelCompleteCheck;

    void Start()
    {
        SetRigidbodyState(true); 
        SetColliderState(false);
        GetComponent<Animator>().enabled = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProgress>();
        levelCompleteCheck = GameObject.FindGameObjectWithTag("LCC").GetComponent<LevelCompleteCheck>();
    }
    public void Die()
    {
        GetComponent<EnemiesController>().enabled = false;
        GetComponent<Animator>().enabled = false;
        SetRigidbodyState(false);
        player.killScore += Random.Range(2, 6);
        player.totalKills++;
        player.koins += Random.Range(2, 6) * player.koinsMultiplier;
        SetColliderState(true);
        GetComponent<NavMeshAgent>().enabled = false;
        audioManager.PlayDeathSound();
        int randSlowMo = Random.Range(0, 10);
        if(randSlowMo > 6)
            levelCompleteCheck.SlowMo(0.05f);
        Destroy(GetComponent<Enemy>());
    }

    private void SetRigidbodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }
        GetComponent<Rigidbody>().isKinematic = !state;
    }
    private void SetColliderState(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }
        GetComponent<Collider>().enabled = !state;
    }
}
