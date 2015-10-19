using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

    public GameObject santa;
    private Vector3 offset;

    // Maintains list of transparent objects and their color
    private Dictionary<Transform, Color> transparentObjects;

	// Use this for initialization
	void Start () {
        InitialiseCamera();
	}

    public void InitialiseCamera()
    {
        offset = transform.position - santa.transform.position;
        transparentObjects = new Dictionary<Transform, Color>();
    }


    void LateUpdate() {
        transform.position = santa.transform.position + offset;

        // transparent objects
        RaycastHit[] hits;
        // Returns all hits
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0f);

        // Maintain list of transform hit by ray
        List<Transform> rayHitTransform = new List<Transform>();

        foreach (RaycastHit hit in hits)
        {
            rayHitTransform.Add(hit.transform);

            // Checks if there is a renderer component
            Renderer rend = hit.transform.GetComponent<Renderer>();
            
            // if renderer exists
            if (rend)
            {
                if (hit.transform.tag == "Transparent")
                {
                    Transform hitTransform = hit.transform;
                    
                    // Add to dictionary only if it doesn't already contain element
                    if (!transparentObjects.ContainsKey(hitTransform))
                    {
                        // Add transform to transparent object map and update transparency
                        transparentObjects.Add(hitTransform, rend.material.color);

                        // Custom Shader imported which writes to Z value
                        rend.material.shader = Shader.Find("Transparent/Diffuse ZWrite");
                        Color tempColor = rend.material.color;
                        tempColor.a = 0.5f;
                        rend.material.color = tempColor;
                    }
                }
            }
        }

        // reset color of objects not hit
        List<Transform> keyList = new List<Transform>(transparentObjects.Keys);
        keyList.RemoveAll(item => rayHitTransform.Contains(item));

        foreach (Transform t in keyList)
        {
            Color originalColor = transparentObjects[t];
            Renderer rend = t.GetComponent<Renderer>();
            rend.material.color = originalColor;

            // Remove from transparent objects
            transparentObjects.Remove(t);
        }

    }
}
