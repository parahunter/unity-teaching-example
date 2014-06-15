using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cannon : MonoBehaviour 
{
	public Rigidbody cannonBallPrefab;
	
	Transform barrel;
	public float startSpeed;
	
	void Awake()
	{
		barrel = transform.Find("Barrel");
	}
	
	void OnDrawGizmosSelected()
	{
		if(barrel == null)
			Awake();
	
		float length = MaxDistanceTraveled(startSpeed, -barrel.rotation.eulerAngles.z, Physics.gravity.y);
		
		Gizmos.DrawLine(transform.position, transform.position + Vector3.right * length);
		
		
		
	}
	
	void Update()
	{
		if(Input.GetButtonDown("Fire1"))
			Fire();
	}	
	
	void Fire()
	{
		Rigidbody cannonBall = (Rigidbody)Instantiate(cannonBallPrefab, transform.position, transform.rotation);
		
		cannonBall.velocity = barrel.up * startSpeed;
	}
	
	float MaxDistanceTraveled(float s, float a, float g)
	{
		float v2 = Mathf.Pow(s, 2);
		float sin2a = Mathf.Sin( 2 * a);
		
		return (v2 * sin2a) / g;
	}
}
