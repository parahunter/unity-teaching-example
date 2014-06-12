using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeController : MonoBehaviour 
{
	
	GizmoExample[] cubeMovers;
	
	Vector3 targetPos;
	
	void Awake()
	{
		cubeMovers = (GizmoExample[])GameObject.FindObjectsOfType<GizmoExample>();
	}
	
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(targetPos, 1f);
		
		
	}
	
	void Update()
	{
		Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		RaycastHit hit;
		if(Physics.Raycast(screenRay, out hit))
		{
			targetPos = hit.point;
		}
		
		foreach(GizmoExample cubeMover in cubeMovers)
		{
			cubeMover.direction = (targetPos - cubeMover.transform.position).normalized;
		}
		
	}
	
	
}
