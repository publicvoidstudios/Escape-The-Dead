using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMesh : MonoBehaviour
{
    [SerializeField]
    public GameObject[] meshes;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, meshes.Length);
        meshes[rand].SetActive(true);
    }
}
