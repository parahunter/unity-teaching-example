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
				
	void Update()
	{
		if(Input.GetButtonDown("Fire1"))
			Fire();
	}	
	
	void Fire()
	{
		Rigidbody cannonBall = (Rigidbody)Instantiate(cannonBallPrefab, transform.position, Quaternion.identity);
		
		cannonBall.velocity = barrel.up * startSpeed;
	}
	
	public float MaxDistanceTraveled(float s, float a, float g)
	{
		float v2 = Mathf.Pow(s, 2);
		float sin2a = Mathf.Sin( 2 * a);
		
		return (v2 * sin2a) / g;
	}
	
	public void SetMaxDistanceTraveled(float d, float a, float g)
	{
		startSpeed = Mathf.Sqrt( ( (d * g ) / Mathf.Sin (2 * a ) ) );
	}
	
	public float GetBulletHeight(float s, float a, float g, float x)
	{
		float s2 = s*s;
		float cos2a = Mathf.Pow( Mathf.Cos(a) , 2);
		float tanAMultX = Mathf.Tan(a) * x; 
		
		return ( g * Mathf.Pow(x, 2) / (2 * s2 * cos2a) ) + tanAMultX;
	}
	
	
	
}
