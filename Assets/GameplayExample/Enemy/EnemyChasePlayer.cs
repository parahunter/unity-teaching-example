using UnityEngine;
using System.Collections;

public class EnemyChasePlayer : MonoBehaviour 
{
	
	public float seekForcce = 100f;
	public ForceMode forceMode = ForceMode.Acceleration;
	
	Transform tankTransform;	
	
	// Use this for initialization
	void Start () 
	{
		tankTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 vectorToTank = tankTransform.position - transform.position;
		vectorToTank.Normalize();
		
		rigidbody.AddForce(vectorToTank * seekForcce, forceMode);
	}
}
