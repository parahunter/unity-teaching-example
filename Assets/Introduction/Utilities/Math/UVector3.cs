using UnityEngine;
using System.Collections;

public static class UVector3
{
	public static Vector3 VectorFromDirection (float direction, float distance, bool inRAdians = false)
	{
		if(!inRAdians)
			direction *= Mathf.PI * 2;
		
		return new Vector3(Mathf.Cos(direction), Mathf.Sin(direction), 0) * distance;
	}
	
}
