using UnityEngine;
using System.Collections;

public class SlideMe : Slide 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#region implemented abstract members of Slide
	protected override void _OnSlideEnter ()
	{
		state = Slide.State.Active;
		//throw new System.NotImplementedException ();
	}

	protected override void _OnSlideExit ()
	{
		
		//	throw new System.NotImplementedException ();
	}
	
	public override void OnSlideFinalise()
	{
		
	}
	#endregion
}
