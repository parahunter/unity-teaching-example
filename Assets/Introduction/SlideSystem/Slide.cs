using UnityEngine;
using System.Collections;

public abstract class Slide : MonoBehaviour 
{
	
	
	[SerializeField]
	private Transform cameraAnchor;
	
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
	
	public abstract void OnSlideEnter();
	
	public abstract void OnSlideExit();
	
}
