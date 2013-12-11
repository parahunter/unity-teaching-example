using UnityEngine;
using System.Collections;

public class TankHealth : MonoBehaviour 
{
	
	
	public float startHealth = 100f;
	
	public float health
	{
		get;
		private set;
	}
	
	// Use this for initialization
	void Start () 
	{
		health = startHealth;
	}
	
	public void TakeDamage(float damage)
	{
		health -= damage;
		
		if(health < 0)
			Destroy(gameObject);
	}
}
