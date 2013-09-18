using UnityEngine;
using System.Collections;

public class BulletExplosion : MonoBehaviour 
{
	//how big the explosion should be
	public float explosionRadius = 3;
	//how powerfull it should be
	public float explosionForce = 300;
	//the explosion visualisation
	public Transform explosion;
	
	//when the bullet hits something
	void OnCollisionEnter(Collision collision)
	{
		//find all nearby colliders (that is gameobjects that reacts to collisions)
		Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, explosionRadius);
		
		//go through them
		foreach(Collider collider in nearbyColliders)
		{
			//if the game object also contains a rigidbody component then it reacts to physics, add an explosion force
			if(collider.rigidbody)
				collider.rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
		}
		
		//create the explosion visualisation
		Instantiate(explosion, transform.position, transform.rotation);
		
		//and destroy the bullet
		Destroy(gameObject);
	}
}
