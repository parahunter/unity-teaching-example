using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(Cannon))]
public class CannonEditor : Editor
{
	Cannon cannon;
	Transform transform;
	Transform barrel;
	
	void OnEnable()
	{
		cannon = (Cannon)target;
		transform = cannon.transform;
		barrel = cannon.transform.Find("Barrel");
	}

	void OnSceneGUI()
	{
		float startSpeed = cannon.startSpeed;
		float a = barrel.rotation.eulerAngles.x;
		float g = -Physics.gravity.y;
		
		float shootLength = cannon.MaxDistanceTraveled( startSpeed, a, g);
		
		Handles.DrawLine(transform.position, transform.position + transform.forward * shootLength);
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
		Vector3 targetPoint = transform.position + cannon.transform.forward * shootLength;
		Vector3 newTargetPoint = Handles.FreeMoveHandle ( targetPoint, cannon.transform.rotation, 0.5f, Vector3.zero, Handles.CircleCap);
		float change = (newTargetPoint - targetPoint).magnitude;
		
		if(GUI.changed)	
		{
			Undo.RecordObject(cannon.transform, "Changed cannon");
			Undo.RecordObject(cannon, "Changed cannon");
				
			Vector3 toTargetPoint = newTargetPoint - cannon.transform.position;
			toTargetPoint.y = 0;
			
			float distance = toTargetPoint.magnitude;
			
			cannon.transform.forward = toTargetPoint;
			
			cannon.SetMaxDistanceTraveled( distance, a, g);
			
			EditorUtility.SetDirty(cannon);
		}
	}	
}
