using UnityEngine;
using System.Collections;

/**
    Combines children meshes together. Must be placed onto empty parent game object
*/
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshCombine : MonoBehaviour {

    // Specifies if children meshes are common materials
    public bool commonMaterial;

	// Use this for initialization
	void Start ()
    {

        // http://forum.unity3d.com/threads/combinemeshes-example-flawed.33209/
        foreach (Transform child in transform)
            child.position += transform.position;

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;

        // Find all children meshes
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int i = 0;
        while(i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.active = false;
            i++;
        }

        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine, commonMaterial);
        transform.gameObject.active = true;

        // Set bound of box collider attached to game object
        BoxCollider collider = GetComponent<BoxCollider>();
        if (collider)
        {
            // set position of collider
            collider.center = GetComponent<MeshFilter>().mesh.bounds.center;
            // set bounds of collider
            collider.size = GetComponent<MeshFilter>().mesh.bounds.size;
        }
	}
	
}
