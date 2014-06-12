using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour 
{
	public Transform bullets;
	
	public void Die()
	{
		Instantiate(bullets, transform.position, transform.rotation);
		
		Destroy(gameObject);
	}	
}
