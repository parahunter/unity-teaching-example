using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlideManager : MonoBehaviour 
{
	public List<Slide> slides;
		
	int currentIndex = 0;
	Slide currentSlide;
	
	public float cameraTransitionSpeed = 1f;	
	
	
	// Use this for initialization
	void Start () 
	{
		currentSlide = slides[currentIndex];
		currentSlide.OnSlideEnter();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Input.GetKeyDown(KeyCode.LeftArrow))
			RewindSlide();
		
		if(Input.GetKeyDown(KeyCode.RightArrow))
			ForwardSlide();
		
	}
	
	public void ForwardSlide()
	{
		if(currentIndex < slides.Count - 1)
			SwitchSlide(1);
	}
	
	public void RewindSlide()
	{
		if(currentIndex > 0)
			SwitchSlide(-1);		
	}
	
	void SwitchSlide(int amount)
	{
		slides[currentIndex].OnSlideExit();
		
		currentIndex += amount;
		
		slides[currentIndex].SetCameraTarget(cameraTransitionSpeed);
		
		slides[currentIndex].OnSlideEnter();
	}
}


