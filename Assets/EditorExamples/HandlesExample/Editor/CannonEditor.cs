using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(Cannon))]
public class CannonEditor : Editor
{
	Cannon cannon;
	Transform barrel;
	
	void OnEnable()
	{
		cannon = (Cannon)target;
		barrel = cannon.transform.Find("Barrel");
	}

	void OnSceneGUI()
	{
		float startSpeed = cannon.startSpeed;
		float a = barrel.rotation.eulerAngles.x;
		float g = -Physics.gravity.y;
		
		float shootLength = cannon.MaxDistanceTraveled( startSpeed, a, g);
		
		Vector3[] trajectory = new Vector3[20];                                                                                                                
		
		for(int i = 0 ; i < trajectory.Length ; i++)
		{
			float x = ((float)i/ trajectory.Length) * shootLength;
			float y = cannon.GetBulletHeight(startSpeed, a, g, x);
			           
			trajectory[i] = cannon.transform.position + cannon.transform.forward * x + cannon.transform.up * 0;
			
		}  
		Handles.DrawPolyLine( trajectory );                                                                                                                                                                                                                                        
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
		Vector3 targetPoint = cannon.transform.position + cannon.transform.forward * shootLength;
		
		Vector3 newTargetPoint = Handles.FreeMoveHandle ( targetPoint, cannon.transform.rotation, 0.5f, Vector3.zero, Handles.CircleCap);
	
		float change = (newTargetPoint - targetPoint).magnitude;
		
		if(!Mathf.Approximately(change, 0))
		{	
			Vector3 toTargetPoint = newTargetPoint - cannon.transform.position;
			toTargetPoint.y = 0;
			
			float distance = toTargetPoint.magnitude;
			
			cannon.transform.forward = toTargetPoint;
			
			cannon.SetMaxDistanceTraveled( distance, a, g);
		}
	}	
}
