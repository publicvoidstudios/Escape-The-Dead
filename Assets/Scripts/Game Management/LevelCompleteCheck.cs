using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteCheck : MonoBehaviour
{
    [SerializeField]
    PlayerProgress player;
    float elapsed;
    [SerializeField, Range(0, 1)]
    float timeScale;
    [SerializeField]
    float fixedDeltaTime;
    bool slowMoActivated;
    void Update()
    {
        if (!slowMoActivated)
        {
            Time.timeScale = timeScale;
        }
        else
        {
            RestoreTimeScale();
        }
        fixedDeltaTime = Time.fixedDeltaTime;    
        Check();
    }

    
    private void Check()
    {
        if (player.killScore >= 100 + player.level * 10)
        {
            player.killScore = 0;
            player.koins += player.level * 10;
            player.level++;
            player.levelUpFX.Play();
        }
    }
    public void SetTimeScale(float from, float to)
    {        
        elapsed += Time.unscaledDeltaTime;
        timeScale = Mathf.MoveTowards(from, to, elapsed);
        if(timeScale == 0)
        {
            return;
        }
    }

    public void SlowMo(float slowdownFactor)
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        slowMoActivated = true;
    }
    public void RestoreTimeScale()
    {
        Time.timeScale += (1f / 2f) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        if (Time.timeScale >= 0.9f)
        {            
            Time.timeScale = 1f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            slowMoActivated = false;
        }
    }

    public void Pause(bool pause)
    {
        if (pause)
        {
            timeScale = 0;
        }
        else
        {
            timeScale = 1;
        }
    }
}
