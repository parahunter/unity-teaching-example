using UnityEngine;
using System.Collections;

public class TankMove : MonoBehaviour 
{
	public float moveForce = 50f; //how fast the tank moves forward and backwards with
	public float rotationForce = 20f; //how fast the tank rotates
	
	//on every physics step
	public void FixedUpdate()
	{
		//get input from player
		float moveInput = Input.GetAxis("Vertical");
		float rotationInput = Input.GetAxis("Horizontal");
		
		//add a force whose direction is the same as the tank's
		//we use velocityChange to make the steering a bit nicer
		rigidbody.AddForce(transform.forward * moveInput * moveForce, ForceMode.VelocityChange);
		
		//add a torque force around the tank's y-axis
		//we use velocityChange to make the steering a bit nicer
		rigidbody.AddTorque(transform.up * rotationInput * rotationForce, ForceMode.VelocityChange);
	}
}
