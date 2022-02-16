using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsOnWalls : MonoBehaviour
{
    [SerializeField]
    PlayerProgress playerProgress;
    [SerializeField]
    GameObject[] gunsOnWalls;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < gunsOnWalls.Length; i++)
        {
            if (playerProgress.purchasedWeapons.Contains(i))
            {
                gunsOnWalls[i].SetActive(true);
            }
            else
            {
                gunsOnWalls[i].SetActive(false);
            }
        }
    }

    public void ReturningFromStore()
    {
        for (int i = 0; i < gunsOnWalls.Length; i++)
        {
            if (playerProgress.purchasedWeapons.Contains(i))
            {
                gunsOnWalls[i].SetActive(true);
            }
            else
            {
                gunsOnWalls[i].SetActive(false);
            }
        }
    }
}
