using UnityEngine;

// Copy meshes from children into the parent's Mesh.
// CombineInstance stores the list of meshes.  These are combined
// and assigned to the attached Mesh.

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class MeshCombiner : MonoBehaviour
{
    [SerializeField]
    GameObject[] allChildren;

    void Start()
    {
        Vector3 position = transform.position;
        transform.position = Vector3.zero;
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int i = 1;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }
        transform.GetComponent<MeshFilter>().sharedMesh = new Mesh();
        transform.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);

        transform.position = position;

        transform.GetComponent<MeshCollider>().sharedMesh = transform.GetComponent<MeshFilter>().mesh;
    }

    public void GetAllChildren()
    {
        allChildren = GetComponentsInChildren<GameObject>();
    }

    public void CM()
    {
        Start();
    }

    public void ActivateAllChildren()
    {
        foreach(GameObject child in allChildren)
        {
            child.SetActive(true);
        }
    }
}