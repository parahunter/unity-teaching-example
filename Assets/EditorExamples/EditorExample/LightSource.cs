using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LightSource 
{
	public Light light;
	public float duration;
	
	public float maxIntensity
	{
		get;
		private set;
	}
	
	public void Init()
	{
		maxIntensity = light.intensity;
	}
	
}
