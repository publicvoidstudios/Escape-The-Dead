using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{
    [SerializeField]
    PlayerProgress playerProgress;
    [SerializeField]
    public List<GameObject> clothes;
    // Start is called before the first frame update
    void Start()
    {
        if (playerProgress.initialLoadComplete)
        {
            SwitchClothes();
        }
        else
        {
            Debug.LogWarning("PLAYER'S DATA ISN'T LOADED YET((( ONE MORE ATTEMPT IN 0.1 SECOND");
            Invoke("SwitchClothes", 0.1f);
        }
    }

    private void SwitchClothes()
    {
        foreach (GameObject cloth in clothes)
        {
            cloth.SetActive(false);
        }
        for (int i = 0; i < playerProgress.purchasedClothes.Count; i++)
        {
            clothes[playerProgress.purchasedClothes[i]].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerProgress.mainMenuInstance && playerProgress.itemSwitched)
        {
            SwitchClothes();
        }
    }
}
