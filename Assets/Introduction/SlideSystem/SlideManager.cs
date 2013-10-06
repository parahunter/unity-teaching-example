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
		currentSlide.OnSlideEnter(this);
		currentSlide.SetCameraTarget(0f);
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
	
	int direction;
	public void OnSlideFinished(Slide slide)
	{
		SwitchSlide(direction);
	}
	
	void SwitchSlide(int amount)
	{
		direction = amount > 0 ? 1 : -1;
		
		if(currentSlide.state == Slide.State.Active && amount > 0)
		{
			currentSlide.OnSlideExit();
			
//			if(currentIndex + amount < slides.Count && currentIndex + amount > 0)
//				slides[currentIndex + amount].OnSlideInit();
//			
//			if(currentIndex - amount < slides.Count && currentIndex - amount > 0)				
//				slides[currentIndex - amount].OnSlideInit();
		}
		else
		{
			currentSlide.OnSlideFinalise();
			currentIndex += amount;
			
			currentSlide = slides[currentIndex];
			slides[currentIndex].SetCameraTarget(cameraTransitionSpeed);
			
			slides[currentIndex].OnSlideEnter(this);
			
		}
		
	}
}


