using UnityEngine;
using System.Collections;

public class SlideMe : Slide 
{
	public Transform quad;
	public float duration = 1f;
	public float verticalSize = 0.01f;
	
	Vector3 originalScale;
		
	// Use this for initialization
	void Start () 
	{
		originalScale = quad.localScale;
		UvProjector.ProjectUvs(new Transform[]{quad}, cameraAnchor, Camera.main); 
	}
	
	#region implemented abstract members of Slide
	protected override void _OnSlideEnter ()
	{
		quad.localScale = originalScale;
		//throw new System.NotImplementedException ();
	}
	
	protected override void _OnSlideInit()
	{
		quad.localScale = originalScale;
	}

	protected override void _OnSlideExit ()
	{
		StartCoroutine(TVTransition(quad));
		
		//	throw new System.NotImplementedException ();
	}
	
	public override void OnSlideFinalise()
	{
		StopAllCoroutines();
		
	}
	
	IEnumerator TVTransition(Transform quad)
	{
		yield return StartCoroutine( pTween.To(duration, 1f, verticalSize, t => 
		{
			Vector3 newSize = originalScale;
			newSize.y *= t;
			
			quad.localScale = newSize;
		}));
		
		yield return StartCoroutine( pTween.To(duration, 1f, 0, t => 
		{
			Vector3 newSize = originalScale;
			newSize.y *= verticalSize;
			newSize.x *= t;
			
			quad.localScale = newSize;
		}));
		
		manager.OnSlideFinished(this);
	}

	
	#endregion
}
