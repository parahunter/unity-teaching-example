using UnityEngine;
using System.Collections;

public class UMathf : MonoBehaviour 
{
	public static float MapToRange(float val, float oldMin, float oldMax, float newMin, float newMax)
	{
		float normalizedVal = (val - oldMin) / (oldMax - oldMin);
		
		return newMin + normalizedVal * (newMax - newMin);	
	}
	
	public static float LinePointDistance(Vector3 lineOrigin, Vector3 lineDirection, Vector3 point)
	{
		Vector3 lineOriginMinusPoint = lineOrigin - point;
		Vector3 projection = lineOriginMinusPoint - Vector3.Dot(lineOriginMinusPoint, lineDirection) * lineDirection;
		
		return projection.magnitude;	
	}
	
	public static float LinePointDistanceSquared(Vector3 lineOrigin, Vector3 lineDirection, Vector3 point)
	{
		Vector3 lineOriginMinusPoint = lineOrigin - point;
		Vector3 projection = lineOriginMinusPoint - Vector3.Dot(lineOriginMinusPoint, lineDirection) * lineDirection;
		
		return projection.sqrMagnitude;	
	}
	
	public static float LinePointDistanceSquared(Ray line, Vector3 point)
	{
		Vector3 lineOriginMinusPoint = line.origin - point;
		Vector3 projection = lineOriginMinusPoint - Vector3.Dot(lineOriginMinusPoint, line.direction) * line.direction;
		
		return projection.sqrMagnitude;	
	}
	
}
