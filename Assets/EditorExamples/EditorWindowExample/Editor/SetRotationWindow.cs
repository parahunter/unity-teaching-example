using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class SetRotationWindow : EditorWindow 
{	
	[MenuItem("Window/Rotation Window")]
	static void CreateWindow()
	{
		EditorWindow.GetWindow<SetRotationWindow>();
	}
	
	void OnGUI()
	{
		if(Selection.gameObjects.Length == 0)
		{
			GUILayout.Label("Select one or more game objects to alter their rotation");
			return;
		}
		
		if(GUILayout.Button("Reset Rotation"))
			SetRotationForSelection( Quaternion.identity );
                		
		if(GUILayout.Button("Random Rotation"))
		{		
			foreach( GameObject go in Selection.gameObjects)
			{
				float xRot = Random.Range(0, 360f);
				float yRot = Random.Range(0, 360f);
				float zRot = Random.Range(0, 360f);
			
				go.transform.rotation = Quaternion.Euler(xRot, yRot, zRot);
			}
		}
		
		GUILayout.Label("Set to direction:", EditorStyles.boldLabel);
		
		GUILayout.BeginHorizontal();
			if(GUILayout.Button("Forward"))
				SetRotationForSelection( Quaternion.LookRotation(Vector3.forward) );
			if(GUILayout.Button("Back"))
				SetRotationForSelection( Quaternion.LookRotation(Vector3.back) );
			if(GUILayout.Button("Right"))
				SetRotationForSelection( Quaternion.LookRotation(Vector3.right) );		
			if(GUILayout.Button("Up"))
				SetRotationForSelection( Quaternion.LookRotation(Vector3.up) );
        GUILayout.EndHorizontal();
										
	}
	
	void SetRotationForSelection(Quaternion rotation)
	{
		foreach( GameObject go in Selection.gameObjects)
		{
			go.transform.rotation = rotation;        
		}
    }
    
	void OnSelectionChange()
	{
		this.Repaint();
	}
	
}
