using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GizmoExample : MonoBehaviour 
{
	public float force = 400f;
	
	public Vector3 direction
	{
		get;
		set;
	}
	
	void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position, transform.position + direction * 3);
		
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + rigidbody.velocity);
	}
	
	void FixedUpdate()
	{
		rigidbody.AddForce(direction * force);	
	}
	
}
