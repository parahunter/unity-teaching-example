using UnityEngine;
using System.Collections;

public class EnemyExplodeOnImpact : MonoBehaviour 
{
	public float damageToTank = 5f;
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Player")
		{
			collision.collider.transform.root.GetComponent<TankHealth>().TakeDamage(damageToTank);
			
			Destroy(gameObject);
		}
	}
}
