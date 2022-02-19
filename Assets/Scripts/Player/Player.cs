using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField]
    LevelLoader levelLoader;
    public GameObject[] waypoints;
    public Enemy[] currentEnemies;
    private NavMeshAgent agent;
    
    [SerializeField]
    private Animator anim;
    private Vector3 previousPosition;
    private float curSpeed;
    [SerializeField]
    PlayerProgress playerProgress;
    [SerializeField]
    Clothes clothes;
    [SerializeField]
    Material helmetMaterial;
    float matTimer;
    bool helmetBroken;
    public bool infected;

    [SerializeField]
    CinemachineVirtualCamera virtualCamera;
    CinemachinePOV pOV;

    [SerializeField]
    AudioSource footstepAudioSource;
        
    bool movementStateChanged;

    private void Awake()
    {
        Time.timeScale = 1f;
        infected = false;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        FindNewWaypoints();
        agent.SetDestination(waypoints[0].transform.position);
        helmetMaterial.SetFloat("_Threshold", 0);
        pOV = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        Application.targetFrameRate = 62;
    }
    void Update()
    {
        FindNewWaypoints();
        GetPlayerSpeed();
        CheckEnemies();
        MoveToNextWaypoint();
        DissolveHelmet();
        RotateCameraWhileMoving();
        FootstepSound();
        if (Time.timeSinceLevelLoad < 15f && infected)
        {
            GPGSManager.GrantAchievementAnywhere(GPGSIds.achievement_vulnerable);
        }
        if(Time.timeSinceLevelLoad >= 300f && !infected)
        {
            GPGSManager.GrantAchievementAnywhere(GPGSIds.achievement_venerable);
        }
    }

    private void RotateCameraWhileMoving()
    {
        if (curSpeed > 0.05f)
        {
            pOV.m_HorizontalRecentering.m_enabled = true;
            pOV.m_VerticalRecentering.m_enabled = true;
            pOV.m_HorizontalRecentering.m_WaitTime = 0.1f;
            pOV.m_VerticalRecentering.m_WaitTime = 0.1f;
            pOV.m_VerticalRecentering.m_RecenteringTime = 0.2f;
            pOV.m_HorizontalRecentering.m_RecenteringTime = 0.2f;
        }
        else
        {
            pOV.m_HorizontalRecentering.m_enabled = false;
            pOV.m_VerticalRecentering.m_enabled = false;
            //pOV.m_HorizontalRecentering.m_WaitTime = 3f;
            //pOV.m_VerticalRecentering.m_WaitTime = 3f;
            //pOV.m_VerticalRecentering.m_RecenteringTime = 2f;
            //pOV.m_HorizontalRecentering.m_RecenteringTime = 2f;
        }
    }

    private void GetPlayerSpeed()
    {
        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;
        //Animate accordingly to speed
        if (curSpeed > 0.05f)
        {
            anim.SetFloat("Vertical", 1.0f, 0, Time.deltaTime);
            if (States != MovementStates.Running)
            {
                movementStateChanged = true;
            }
            States = MovementStates.Running;
        }
        else
        {
            anim.SetFloat("Vertical", 0.0f, 0, Time.deltaTime);
            if (States != MovementStates.Standing)
            {
                movementStateChanged = true;
            }
            States = MovementStates.Standing;
        }
    }

    private void FootstepSound()
    {
        if (movementStateChanged)
        {
            if (States == MovementStates.Running)
            {
                footstepAudioSource.Play();
            }
            if (States == MovementStates.Standing)
            {
                footstepAudioSource.Stop();
            }
            movementStateChanged = false;
        }
    }
        

    private MovementStates States;

    private enum MovementStates
    {
        Running,
        Standing
    }
    private void CheckEnemies()
    {
        if (waypoints.Length >= 3)
        {
            currentEnemies = waypoints[waypoints.Length - 2].GetComponentsInChildren<Enemy>();
        }
        else if (waypoints.Length == 2)
        {
            currentEnemies = waypoints[0].GetComponentsInChildren<Enemy>();
        }

    }
    private void MoveToNextWaypoint()
    {
        if (currentEnemies.Length == 0)
        {
            agent.SetDestination(waypoints[waypoints.Length - 1].transform.position);
        }
    }
    private void FindNewWaypoints()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    private void DissolveHelmet()
    {
        if (helmetBroken)
        {
            matTimer += 0 + Time.deltaTime;
            helmetMaterial.SetFloat("_Threshold", matTimer);
            if (matTimer >= 1)
            {
                clothes.clothes[1].SetActive(false);
            }
        }        
    }
    public void Die()
    {
        if (!levelLoader.nowLoading)
        {
            if (playerProgress.extraLife)
            {
                playerProgress.extraLife = false;
                Debug.Log("Extra life spent");
                playerProgress.purchasedClothes.Remove(1);
                Debug.Log("Helmet removed from stash");
                helmetBroken = true;
                //clothes.clothes[1].SetActive(false);
                playerProgress.Save();

                return;
            }
            else
            {
                //Get final canvas
                infected = true;
                playerProgress.Save();
                //Interstital ADs must be there
            }
        }        
    }
}
