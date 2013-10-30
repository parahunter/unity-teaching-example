using UnityEngine;
using System.Collections;

public class SlidePlatforms : Slide 
{
	
	public Rigidbody[] boxes;
	
	public float slurpTime = 0.5f;
	public float timeBetweenSlurps = 0.4f;
	
	private class Box
	{
		public Transform transform;
		public Rigidbody rigidbody;
		public Renderer renderer;
		public Vector3 originalPosition;
		public Quaternion originalRotation;
		public Collider collider;
	}
	
	int counter = 0;
	
	Box[] _boxes;
	
	// Use this for initialization
	public void Start () 
	{
		_boxes = new Box[boxes.Length];
		
		for(int i = 0 ; i < boxes.Length ; i++)
		{
			Box box = new Box();
			box.rigidbody = boxes[i];
			box.transform = box.rigidbody.transform;
			box.originalPosition = box.transform.position;
			box.originalRotation = box.transform.rotation;
			box.renderer = box.transform.renderer;
			box.collider = box.transform.collider;
			
			_boxes[i] = box;
		}
		
		_ResetBoxes();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Input.GetKeyDown(KeyCode.Space) && animatingOut == false)
			_ReleaseBox();
	}
	
	protected override void _OnSlideExit ()
	{
		StartCoroutine(_AnimateOut());
	}
	
	protected override void _OnSlideEnter ()
	{
		base._OnSlideEnter ();
		
		
	}
	
	private void _ResetBoxes()
	{
		foreach(Box box in _boxes)
		{
			_ResetBox(box);
		}
		
		counter = 0;
	}
	
	private void _ResetBox(Box box)
	{
		box.renderer.enabled = false;
		box.rigidbody.isKinematic = true;
		box.collider.enabled = false;
		box.transform.position = box.originalPosition;
		box.transform.rotation = box.originalRotation;
	}
	
	private void _ReleaseBox() 
	{
		if(counter >= _boxes.Length)
		{
//			if(!animatingOut)
//			{
//				StartCoroutine(_AnimateOut());
//				animatingOut = true;
//			}
			
			return;
		}
		
		Box box = _boxes[counter];
		
		box.collider.enabled = true;
		box.renderer.enabled = true;
		box.rigidbody.WakeUp();
		box.rigidbody.isKinematic = false;
		
		counter++;
	}
	
	bool animatingOut = false;
	
	IEnumerator _AnimateOut()
	{
		foreach(Box box in _boxes)
		{
			StartCoroutine(_SlurpBox(box));
			yield return new WaitForSeconds(timeBetweenSlurps);
		}
		
		yield return new WaitForSeconds(slurpTime);
		
		
		
		transform.parent.GetComponent<SlideManager>().OnSlideFinished(this);
	}
	
	IEnumerator _SlurpBox(Box box)
	{
		
		Vector3 startPosition = box.transform.position;
		Quaternion startRotation = box.transform.rotation;
		
		yield return StartCoroutine(pTween.To(slurpTime, 0, 1, t =>
		{
			box.transform.position = Vector3.Lerp(startPosition, box.originalPosition, t);
			box.transform.rotation = Quaternion.Lerp(startRotation, box.originalRotation, t);
			
		}));
		
		_ResetBox(box);
	}
	
	#region implemented abstract members of Slide
	public override void OnSlideFinalise ()
	{
		_ResetBoxes();
		//throw new System.NotImplementedException ();
	}
	#endregion
}
