using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlideIntroduction : Slide 
{
	
	public float minREmoveTime = 0.3f;
	public float maxRemoveTime = 0.5f;
	
	
	List<Transform> cubes = new List<Transform>();
	
	// Use this for initialization
	void Start () 
	{
		Transform[] targets = new Transform[1];
//		targets[0] = transform.Find("Cube");
//		Matrix4x4 view = Camera.main.projectionMatrix;
//		
//		UvProjector.ProjectUvs(targets, cameraAnchor, view);
//		
		
		Transform pivot = transform.Find("Pivot");
		
		foreach(Transform child in pivot)
		{
			cubes.Add(child);
		}
	}
	
	#region implemented abstract members of Slide
	
	protected override void _OnSlideEnter()
	{
		foreach(Transform cube in cubes)
		{
			cube.localScale = Vector3.one;
		}
	}
	
	protected override void _OnSlideExit ()
	{
		StartCoroutine(RemoveCubes());
	}
	
	IEnumerator RemoveCubes()
	{
		foreach(Transform cube in cubes)
		{
			float delay = Random.Range(minREmoveTime, maxRemoveTime);
			
			StartCoroutine(RemoveCube(cube, delay));
		}
		
		yield return new WaitForSeconds(maxRemoveTime);
		
		manager.OnSlideFinished(this);
	}
	
	IEnumerator RemoveCube(Transform cube, float delay)
	{
		yield return new WaitForSeconds(delay);
		
		cube.localScale = Vector3.zero;
	}
	
	
	public override void OnSlideFinalise ()
	{
		//throw new System.NotImplementedException ();
	}
	
	
	
	#endregion
}
