using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField]
    PlayerProgress playerProgress;
    // Start is called before the first frame update
    void OnEnable()
    {
        playerProgress.koinsMultiplier *= 2;
    }
}
