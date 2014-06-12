using UnityEngine;
using System.Collections;

public class DisplayBulletCount : MonoBehaviour 
{
	
	public Rect countPosition; //where should the score be placed?
	
	public TankShoot shootScript; //reference to the script with the bullet count
	public TankHealth healthScript; //reference to the script with the health count
	
	//when we want to draw GUI it happens inside this function
	void OnGUI()
	{
		//draw some text
		GUI.Label(countPosition, "bullets: " + shootScript.bulletCount + " \nhealth: " + healthScript.health);
		
	}
}