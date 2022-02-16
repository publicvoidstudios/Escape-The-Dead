using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemiesController : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField]
    private GameObject player;
    private Animator animator;
    private int randomBehaviour;
    [SerializeField]
    float stopDistanceDefault = 20;
    float stopDistance;
    [SerializeField]
    float attackDistanceDefault = 1.5f;
    float attackDistance;
    float deathTimer;

    Vector3 previousPosition;
    float curSpeed;
    Player playerScript;
    


    [SerializeField]
    AudioManager audioManager;
    bool stateChanged = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        State = States.idle;
        RandomizeBehaviour();
        stopDistance = stopDistanceDefault;
        attackDistance = attackDistanceDefault;
        PlayStateSound();
    }

    void Update()
    {
        MoveToPlayer();
        CheckStateChange();
    }
    private void RandomizeBehaviour()
    {
        randomBehaviour = Random.Range(0, 2);
        animator.SetInteger("BehaveSeed", randomBehaviour);
    }
    private States State
    {
        get { return (States)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    private void CheckStateChange()
    {
        AudioSource audioSource = audioManager.sounds[audioManager.nowPlayingID].source;
        if (stateChanged || playerScript.infected || audioSource.time == 0)
        {
            PlayStateSound();
            stateChanged = false;
        }
    }

    private void PlayStateSound()
    {
        audioManager.StopAllSounds();
        if (State == States.walk && !playerScript.infected) //Moving
        {
            audioManager.PlayWalkingSound();
        }
        else if (State == States.idle && !playerScript.infected) //Idling
        {
            audioManager.PlayIdleSound();
        }
        else if (State == States.attack && !playerScript.infected) //Attacking
        {
            audioManager.PlayAttackingSound();
        }
        else if (playerScript.infected || Time.timeScale == 0)
        {
            audioManager.StopAllSounds();
        }
    }

    private void MoveToPlayer()
    {
        //Stay
        if(Vector3.Distance(transform.position, player.transform.position) > stopDistance)
        {
            if(State != States.idle)
            {
                stateChanged = true;
            }
            if (agent != null)
            {
                agent.isStopped = true;
            }
            State = States.idle;
            
        }
        //Walk
        else if(Vector3.Distance(transform.position, player.transform.position) > attackDistance && Vector3.Distance(transform.position, player.transform.position) < stopDistance)
        {
            if(State != States.walk)
            {
                stateChanged = true;
            }
            State = States.walk;
            if(agent != null)
            {
                agent.isStopped = false;
                if (agent.isOnNavMesh)
                {
                    agent.SetDestination(player.transform.position);
                }                
            }
            
        }
        //Attack
        else if(Vector3.Distance(transform.position, player.transform.position) < attackDistance)
        {
            if(State != States.attack)
            {
                stateChanged = true;
            }
            TurnToPlayer();
            if (agent != null)
            {
                agent.isStopped = true;
            }
            State = States.attack;
            
            deathTimer += Time.deltaTime;
            if(deathTimer >= 1)
            {
                deathTimer = 0;
                player.GetComponent<Player>().Die();
                return;
            }
        }
    }
    private void TurnToPlayer()
    {
        transform.LookAt(player.transform);
    }
    private enum States
    {
        idle,
        walk,
        attack
    }
}
