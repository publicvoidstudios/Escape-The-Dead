using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuZombieAnimationRandomizer : MonoBehaviour
{
    [SerializeField]
    Animator[] animators;
    [SerializeField]
    float nextAnimationTime;
    [SerializeField]
    float randomTime;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextAnimationTime)
        {
            SetNewRandomTime();
            nextAnimationTime = Time.time + randomTime;
            SwitchAnimation();
        }
    }

    private void SwitchAnimation()
    {
        int randomAnimation = Random.Range(0, 3);
        foreach(Animator animator in animators)
        {
            animator.SetInteger("Rand", randomAnimation);
        }
    }

    private void SetNewRandomTime()
    {
        randomTime = Random.Range(5, 15);
    }
}
