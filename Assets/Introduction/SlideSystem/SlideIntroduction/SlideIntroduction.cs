using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlideIntroduction : Slide 
{
	public float minREmoveTime = 0.3f;
	public float maxRemoveTime = 0.5f;
	public float scaleDownTime = 0.3f;
	public float delayAfterwards = 0.1f;
	
	List<Transform> cubes = new List<Transform>();
	List<Vector3> scales = new List<Vector3>();
	
	// Use this for initialization
	void Start () 
	{
		Transform[] targets = new Transform[1];
//		targets[0] = transform.Find("Cube");

		Transform pivot = transform.Find("Pivot");
		
		foreach(Transform child in pivot)
		{
			cubes.Add(child);
			scales.Add(child.localScale);
		}
		
		
		UvProjector.ProjectUvs(cubes.ToArray(), cameraAnchor, Camera.main);
	}
		
	#region implemented abstract members of Slide
	
	protected override void _OnSlideEnter()
	{
		for(int i = 0 ; i < cubes.Count ; i++)
		{
			cubes[i].localScale = scales[i];
			
			//cube.localScale = Vector3.one;
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
		
		yield return new WaitForSeconds(maxRemoveTime + scaleDownTime + delayAfterwards);
		
		manager.OnSlideFinished(this);
	}
	
	IEnumerator RemoveCube(Transform cube, float delay)
	{
		yield return new WaitForSeconds(delay);
		Vector3 startScale = cube.localScale;
		
		yield return StartCoroutine(pTween.To(scaleDownTime, 0f, 1f, t =>
		{
			cube.localScale = Vector3.Lerp(startScale, Vector3.zero, t);
		})	
		);
		
		cube.localScale = Vector3.zero;
	}
	
	
	public override void OnSlideFinalise ()
	{
		//throw new System.NotImplementedException ();
	}
	
	
	
	#endregion
}
