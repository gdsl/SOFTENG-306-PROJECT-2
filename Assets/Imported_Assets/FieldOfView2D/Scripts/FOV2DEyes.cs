using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FOV2DEyes : MonoBehaviour
{
	public bool raysGizmosEnabled;
	//public float updateRate = 0.02f;
	public int quality = 4;
	public int fovAngle = 90;
	public float fovMaxDistance = 15;
	//public LayerMask cullingMask;
	public List<RaycastHit> hits = new List<RaycastHit>();
	
	int numRays;
	float currentAngle;
	Vector3 direction;
	RaycastHit hit;

    private int layerMask;

    void Update()
	{
        // Get fov and fovMaxDistance values
        PersonSight personSight = GetComponent<PersonSight>();
        if (personSight)
        {
            fovAngle = (int)personSight.fieldOfViewAngle;
        }

        SphereCollider collider = GetComponent<SphereCollider>();
        if (collider)
        {
            fovMaxDistance = collider.radius;
        }

		CastRays();
	}
	
	void Start() 
	{
        //InvokeRepeating("CastRays", 0, updateRate);
        // Collide with everything except layer 2
        layerMask = 1 << 2;
        // invert
        layerMask = ~layerMask;
    }
	
	void CastRays()
	{
		numRays = fovAngle * quality;
		currentAngle = fovAngle / -2;
		
		hits.Clear();
		
		for (int i = 0; i < numRays; i++)
		{
			direction = Quaternion.AngleAxis(currentAngle, transform.up) * transform.forward;
			hit = new RaycastHit();
			
			if(Physics.Raycast(transform.position + transform.up, direction, out hit, fovMaxDistance, layerMask) == false)
			{
				hit.point = transform.position + transform.up + (direction * fovMaxDistance);
			}
			
			hits.Add(hit);

			currentAngle += 1f / quality;
		}
	}
	
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		
		if (raysGizmosEnabled && hits.Count() > 0) 
		{
			foreach (RaycastHit hit in hits)
			{
				Gizmos.DrawSphere(hit.point, 0.04f);
				Gizmos.DrawLine(transform.position + transform.up, hit.point);
			}
		}
	}
	
}
