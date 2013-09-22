using UnityEngine;
using System.Collections;

public abstract class Slide : MonoBehaviour 
{
	
	[HideInInspector()]
	[SerializeField]
	protected Transform cameraAnchor;
	
	protected SlideManager manager;
	
	public enum State
	{
		Inactive,
		Active
	}
	
	public State state
	{
		get;
		protected set;
	}
	
	public void Reset()
	{
		if(transform.Find("CameraAnchor") == null)
		{		
			GameObject cameraObject = new GameObject("CameraAnchor");
			cameraObject.transform.parent = transform;
			cameraObject.transform.localPosition = Vector3.zero;
			cameraObject.transform.localRotation = Quaternion.identity;
			
			cameraAnchor = cameraObject.transform;
		}
		else
			cameraAnchor = transform.Find("CameraAnchor");
	}
	
	public void SetCameraTarget(float transitionTime)
	{
		CameraControl.instance.GoToTransform( cameraAnchor, transitionTime);	
	}
	
	public void OnSlideEnter(SlideManager manager)
	{
		StopAllCoroutines();
		this.manager = manager;
		state = State.Active;
		_OnSlideEnter();
	}
	
	protected virtual void _OnSlideEnter()
	{
		
	}
	
	public void OnSlideExit()
	{
		state = State.Inactive;
		_OnSlideExit();
	}
	
	protected virtual void _OnSlideExit()
	{
		
	}
	
	
	public abstract void OnSlideFinalise();
	
}
