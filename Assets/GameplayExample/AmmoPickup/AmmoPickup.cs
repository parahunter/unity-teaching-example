using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour 
{
	//how much ammo the pickup gives
	public int amount = 3;
	
	
	
	//when we collide with something
	//OnTriggerEnter is used since the pickup has a trigger collider
	void OnTriggerEnter(Collider other)
	{
		//if it was the tank we collided with
		if(other.tag == "Player")
		{
			//find the shoot script on the tank and add some bullets
			GameObject.Find("Tank").GetComponentInChildren<TankShoot>().AddAmmo(3);
			
			//then destroy the pickup
			Destroy(gameObject);
		}
	}	
}
