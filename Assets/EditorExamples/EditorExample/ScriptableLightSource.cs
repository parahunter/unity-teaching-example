using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScriptableLightSource : ScriptableObject //needs to inherit from this in order to work with serialised properties
{
	public Light light;
	public float duration = 1f;	
}
