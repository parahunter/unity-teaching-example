using UnityEngine;
using System.Collections;

public class SlideExample : Slide
{
	
	
	public float tweenTime = 0.6f;
	public float delayBeforeSceneChange = 0.1f;
	
	public Transform secondaryAnchor;
	
	protected override void _OnSlideEnter ()
	{
		StartCoroutine(_SwitchScene());
	}
	
	IEnumerator _SwitchScene()
	{
		Camera.main.GetComponent<CameraControl>().GoToTransform(secondaryAnchor, tweenTime);
		
		yield return new WaitForSeconds(delayBeforeSceneChange + tweenTime);
		
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	

	#region implemented abstract members of Slide
	public override void OnSlideFinalise ()
	{
		
	}
	#endregion
}
