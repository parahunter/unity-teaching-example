using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomPropertyDrawer(typeof(LightSource))]
public class LightSourceDrawer : PropertyDrawer
{
	const string lightpath = "light";
	const string durationpath = "duration";
	const float lightRectWidth = 200f;
	
//	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
//	{
//		return base.GetPropertyHeight (property, label);
//	}
	
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty (position, label, property);
		
		// Draw label
		position = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), label);
		
		// Don't make child fields be indented
		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;
	
		var lightRect = new Rect(position.x, position.y, lightRectWidth, position.height);
		var durationRect = new Rect(position.x + lightRectWidth, position.y, position.width - lightRectWidth, position.height);
	
		//color field the same as the light source if it is assigned
		Color guiColor = GUI.color;
		
		Light light = property.FindPropertyRelative (lightpath).objectReferenceValue as Light;
		if(light != null)
			GUI.color = light.color;
	
		EditorGUI.PropertyField (lightRect, property.FindPropertyRelative (lightpath), GUIContent.none);
		EditorGUI.PropertyField (durationRect, property.FindPropertyRelative (durationpath), GUIContent.none);
			
		// Set gui state back to what it was before
		GUI.color = guiColor;
		EditorGUI.indentLevel = indent;
		
		EditorGUI.EndProperty ();
	}
			
}
