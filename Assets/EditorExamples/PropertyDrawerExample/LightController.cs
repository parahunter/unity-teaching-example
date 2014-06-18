using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightController : MonoBehaviour 
{
	public List<LightSource> lightSources = new List<LightSource>();
	
	IEnumerator Start()
	{
		int counter = 0;
		
		while(lightSources.Count > 0)
		{
			LightSource lightSource = lightSources[ counter % lightSources.Count];
			
			lightSource.light.enabled = true;
			
			yield return new WaitForSeconds( lightSource.duration );
			
			lightSource.light.enabled = false;
			
			counter++;
		}
		
	}
}
