using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour 
{
	public AnimationCurve positionInterpolation;
	public AnimationCurve rotationInterpolation;
	
	public static CameraControl instance
	{
		get;
		private set;
	}
	
	// Use this for initialization
	void Start () 
	{
		if(!instance)
		{
			instance = this;
		}
	}
	
	
	
	Transform _target;
	float _time;
	public void GoToTransform(Transform target, float time = 2f)
	{
		StopCoroutine("_Move");
		
		_target = target;
		_time = time;
		
		StartCoroutine("_Move");
	}
		
	IEnumerator _Move()
	{
		Vector3 startPos = transform.position;
		Vector3 endPos = _target.position;
		
		Quaternion startRot = transform.rotation;
		Quaternion endRot = _target.rotation;
		
		for( float t = 0 ; t < _time ; t += Time.deltaTime )
		{
			float normalizedT = t / _time;
			float transformT = positionInterpolation.Evaluate(normalizedT);
			float rotationT = rotationInterpolation.Evaluate(normalizedT);
			
			transform.position = Vector3.Lerp(startPos, endPos, transformT);
			transform.rotation = Quaternion.Slerp(startRot, endRot, rotationT);
			
			yield return 0;	
		}
		
		transform.position = endPos;
		transform.rotation = endRot;
			
	}
}
