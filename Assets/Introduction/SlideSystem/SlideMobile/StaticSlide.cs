using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StaticSlide : Slide 
{
	
	List<Transform> cubes = new List<Transform>();
	
	public Material slideMaterial;
	
	// Use this for initialization
	void Start () 
	{
		Transform[] targets = new Transform[1];
	
		Transform pivot = transform.Find("Pivot");
		
		foreach(Transform child in pivot)
		{
			child.renderer.material = slideMaterial;
			cubes.Add(child);
		}
		
		UvProjector.ProjectUvs(cubes.ToArray(), cameraAnchor, Camera.main);
	}
	
	#region implemented abstract members of Slide
	public override void OnSlideFinalise ()
	{
		
	}
	#endregion
	
}
