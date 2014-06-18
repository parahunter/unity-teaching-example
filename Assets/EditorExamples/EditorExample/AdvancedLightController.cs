using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdvancedLightController : MonoBehaviour 
{
	public List<ScriptableLightSource> lightSources = new List<ScriptableLightSource>();
	
	IEnumerator Start()
	{
		int counter = 0;
		
		while(lightSources.Count > 0)
		{
			ScriptableLightSource lightSource = lightSources[ counter % lightSources.Count];
			
			lightSource.light.enabled = true;
			
			yield return new WaitForSeconds( lightSource.duration );
			
			lightSource.light.enabled = false;
			
			counter++;
		}
	}
	
	void OnDestroy()
	{
		foreach (ScriptableLightSource lightSource in lightSources)
			DestroyImmediate(lightSource);
	}
}
