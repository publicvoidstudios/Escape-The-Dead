using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField]
    PlayerProgress player;
    public GameObject[] weapons;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        weapons[player.activeWeapon].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.mainMenuInstance && player.itemSwitched)
        {
            foreach (GameObject weapon in weapons)
            {
                weapon.SetActive(false);
            }
            weapons[player.activeWeapon].SetActive(true);            
        }
    }
}
