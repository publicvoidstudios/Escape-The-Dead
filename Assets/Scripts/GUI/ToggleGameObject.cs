using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    [SerializeField]
    GameObject[] objectsToToggle;

    public void ToggleObject()
    {
        foreach(GameObject obj in objectsToToggle)
        {
            bool currentState = obj.activeInHierarchy;
            obj.SetActive(!currentState);
        }
        
    }
}
