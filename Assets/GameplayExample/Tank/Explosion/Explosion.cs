using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour 
{
	public float timeToStay = 0.5f; //how long before we remove the explosion again
	public float scalingPerSecond = 3f; //how fast it should grow
	
	// Use this for initialization
	void Start () 
	{
		//Invoke allows us to tell unity to run a method with a delay
		Invoke("Remove", timeToStay);
	}
	
	void Remove()
	{
		Destroy(gameObject);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//scale the game object so the explosion appears to grow
		transform.localScale *= 1 + scalingPerSecond * Time.deltaTime;
	}
}
