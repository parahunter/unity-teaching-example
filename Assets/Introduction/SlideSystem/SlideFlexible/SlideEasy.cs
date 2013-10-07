using UnityEngine;
using System.Collections;

public class SlideFlexible : Slide 
{
	
	Renderer quadRenderer;
	public float fadeTime = 0.5f;
	
	
	void Start()
	{
		Transform quad = transform.Find("Quad");
		quadRenderer = quad.renderer;
		
		UvProjector.ProjectUvs(new Transform[]{quad}, cameraAnchor, Camera.main); 
	}
	
	protected override void _OnSlideExit ()
	{
		StartCoroutine(_AnimateFade());
	}
		
	void _SetOpacity(float alpha)
	{
		quadRenderer.material.color = new Color(1, 1,1, alpha);
	}
	
	IEnumerator _AnimateFade()
	{
		yield return StartCoroutine(pTween.To(fadeTime, 1,0, t =>
		{
			_SetOpacity(t);
		}));
		
		manager.OnSlideFinished(this);
	}
	
	protected override void _OnSlideEnter ()
	{
		_SetOpacity(1f);
	}
	
	protected override void _OnSlideInit ()
	{
		_SetOpacity(1f);
	}
				
	#region implemented abstract members of Slide
	public override void OnSlideFinalise ()
	{
		StopAllCoroutines();
		//throw new System.NotImplementedException ();
	}
	#endregion
}
