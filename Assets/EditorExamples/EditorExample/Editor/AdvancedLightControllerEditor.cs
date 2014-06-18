using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(AdvancedLightController))]
public class AdvancedLightControllerEditor : Editor 
{
	const string lightsCountPath = "lightSources.Array.size";
	const string lightsArrayPath = "lightSources.Array";
	const string lightsDataPath = "lightSources.Array.data[{0}]";
	const string lightPath = "light";
	const string durationPath = "duration";
	
	string upArrow;
	string downArrow;
	
	SerializedObject serializedObject;
	AdvancedLightController controller;
		
	SerializedProperty arrayCount;
	SerializedProperty array;
		
	//SerializedProperty 
	
	void OnEnable()
	{
		upArrow = '\u25B2'.ToString();
		downArrow = '\u25BC'.ToString();
		
		serializedObject = new SerializedObject(target);
		arrayCount = serializedObject.FindProperty(lightsCountPath);
		array = serializedObject.FindProperty(lightsArrayPath);
		controller = (AdvancedLightController)target;
	}		
		
	UnityEngine.Object GetLightSource(int index)
	{
		return serializedObject.FindProperty( string.Format(lightsDataPath, index) ).objectReferenceValue;
	}
	
	void SetLightSource(int index, UnityEngine.Object obj)
	{
	 	serializedObject.FindProperty( string.Format(lightsDataPath, index) ).objectReferenceValue = obj;		
	}
	
	void Swap(int a, int b)
	{
		UnityEngine.Object cachedObject = GetLightSource( a );
		SetLightSource(a, GetLightSource(b));
		
		SetLightSource(b, cachedObject);
	}
	
	void Delete(int index) //this is not done through SerializedProperty because it breaks when you use Undo
	{
		controller.lightSources.RemoveAt(index);
	}
	
	void Add()
	{
		ScriptableLightSource lightSource = ScriptableLightSource.CreateInstance<ScriptableLightSource>();
				
		controller.lightSources.Add( lightSource );
	}
	
	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		
		var indexToDelete = -1;
		for(var i = 0 ; i < arrayCount.intValue ; i++)
		{
			GUILayout.BeginHorizontal();
				
				if(i == 0)
					GUI.enabled = false;
				
				if(GUILayout.Button(upArrow, EditorStyles.miniButton, GUILayout.ExpandWidth(false)))
					Swap (i, i-1);
					
				GUI.enabled = true;
				
				if(i == arrayCount.intValue - 1)
					GUI.enabled = false;
				
				if(GUILayout.Button(downArrow, EditorStyles.miniButton, GUILayout.ExpandWidth(false)))
					Swap (i, i+1);
			
				GUI.enabled = true;
				
				Color guiColor = GUI.color;
				
				//we can't use a property here because the scriptable object exists as its own entity so we need to access that directly
				ScriptableLightSource lightSource = serializedObject.FindProperty(string.Format(lightsDataPath, i)).objectReferenceValue as ScriptableLightSource;
				
				if(lightSource.light != null)
					GUI.color = lightSource.light.color;
				
				lightSource.light = (Light)EditorGUILayout.ObjectField( lightSource.light, typeof(Light), true);
				lightSource.duration = EditorGUILayout.FloatField( lightSource.duration, GUILayout.Width(50));				
																
				GUI.color = guiColor;
				
				if(GUILayout.Button("X", EditorStyles.miniButton, GUILayout.ExpandWidth(false)))
				{
					DestroyImmediate(lightSource); //need to clean up ScriptableObject
					indexToDelete = i;
				}					
			GUILayout.EndHorizontal();
		}
		
		if(GUILayout.Button("Add"))
			Add ();
			
		if(indexToDelete > -1)
			Delete(indexToDelete);																	
																																																			
		serializedObject.ApplyModifiedProperties();			
	}																					
}
