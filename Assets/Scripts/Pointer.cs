using System.Collections;
using System.Collections.Generic;
using CnControls;
using UnityEngine;

public class Pointer : MonoBehaviour
{

	public Animation animation;
	public GreenZone greenZone;
	public Dropper dropper;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CnInputManager.GetButtonDown("Jump"))
		{
			animation.Stop();
			if (greenZone.pointerInGreen())
			{
				Debug.Log("In green");
				dropper.DropCow();
			}
			else
			{
				Debug.Log("Nope");
			}
			animation.Play();
		}
	}
}
