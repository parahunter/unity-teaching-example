using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour 
{
	public Transform enemy;
	public Transform[] spawnPoints;
	
	public AnimationCurve spawnTimes;
	
	int counter = 0;
	
	void Awake()
	{
		StartCoroutine(_Spawn());
	}
	
	IEnumerator _Spawn()
	{
		while(true)
		{
			int spawnNumber = Random.Range(0, spawnPoints.Length);
			Vector3 spawnPosition = spawnPoints[spawnNumber].position;
			
			Instantiate(enemy, spawnPosition, Quaternion.identity);
			
			yield return new WaitForSeconds(spawnTimes.Evaluate(counter));		
			
			counter++;
		}
	}
	
	
}
