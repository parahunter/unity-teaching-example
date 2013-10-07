using UnityEngine;
using System.Collections;

public class SlideFlexible : Slide 
{
	public AnimationCurve curve;
	
	Renderer quadRenderer;
	Transform quad;
	
	// Use this for initialization
	void Start()
	{
		quad = transform.Find("Quad");
		quadRenderer = quad.renderer;
		
		UvProjector.ProjectUvs(new Transform[]{quad}, cameraAnchor, Camera.main); 
	}
	
	protected override void _OnSlideEnter ()
	{
		float twirliness = curve.Evaluate(0);
		quadRenderer.material.SetFloat("_twirliness", twirliness);
		quadRenderer.enabled = true;
	}
	
	protected override void _OnSlideExit ()
	{
		StartCoroutine(_AnimateTwirl());
	}
	
	IEnumerator _AnimateTwirl()
	{
		yield return StartCoroutine(pTween.To(curve.lastTime(), 0, curve.lastTime(), t =>
		{
			float twirliness = curve.Evaluate(t);
			quadRenderer.material.SetFloat("_twirliness", twirliness);
		}));
		
		manager.OnSlideFinished(this);
	}
	

	#region implemented abstract members of Slide
	public override void OnSlideFinalise ()
	{
		quadRenderer.enabled = false;
		StopAllCoroutines();	
	}
	#endregion
}
