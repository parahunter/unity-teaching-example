using UnityEngine;
using System.Collections;

public class TankShoot : MonoBehaviour 
{
	public Transform bulletPrefab; 
	public float shootVelocity = 10f; //speed the bullet should be fired with
	
	//how many bullets the cannon contains, this should not be public but it makes the code more easy to understand for newbies ;-)
	public int bulletCount = 10;
	// Update is called once per frame
	void Update () 
	{
		//if the player has pressed the fire button and there is still bullets left
		if(Input.GetButtonDown("Fire1") && bulletCount > 0)
		{
			//create a bullet at the center of the cannon
			Transform bullet = (Transform)Instantiate (bulletPrefab, transform.position, transform.rotation);
			
			//this is necessary in order for the bullet not to explode as soon as it is created
			Physics.IgnoreCollision(collider, bullet.collider);
			
			//add a speed to the bullet
			bullet.rigidbody.AddForce(transform.forward * shootVelocity, ForceMode.VelocityChange); 
			
			//decrease the amount of bullets we have
			bulletCount--;
		}
	}
		
	public void AddAmmo(int amount) //call this to add bullets to the cannon
	{
		bulletCount += amount;	
	}
}
