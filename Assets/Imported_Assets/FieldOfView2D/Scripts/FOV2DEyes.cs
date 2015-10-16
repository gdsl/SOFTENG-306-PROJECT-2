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
    private PersonSight personSight;
    private SphereCollider collider;
    private Vector3 yOffset;

    void Update()
	{
        // Get fov and fovMaxDistance values
        if (personSight)
        {
            fovAngle = (int)personSight.fieldOfViewAngle;
        }

        if (collider)
        {
            fovMaxDistance = collider.radius;
        }

		CastRays();
	}
	
	void Start() 
	{
        //InvokeRepeating("CastRays", 0, updateRate);
        personSight = GetComponent<PersonSight>();
        collider = GetComponent<SphereCollider>();

        yOffset = personSight.GetRayPos1();
        
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
			
			if(Physics.Raycast(transform.position + yOffset, direction, out hit, fovMaxDistance, layerMask) == false)
			{
				hit.point = transform.position + yOffset + (direction * fovMaxDistance);
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
				Gizmos.DrawLine(transform.position + yOffset, hit.point);
			}
		}
	}
	
    public Vector3 GetYOffset()
    {
        return yOffset;
    }
}
