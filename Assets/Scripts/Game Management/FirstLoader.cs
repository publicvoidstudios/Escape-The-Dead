using UnityEngine;

public class FirstLoader : MonoBehaviour
{
    [SerializeField]
    LevelLoader levelLoader;
    void Start()
    {
        levelLoader.LoadLevel("MainMenu");
        levelLoader.playerReady = true;
    }
}
