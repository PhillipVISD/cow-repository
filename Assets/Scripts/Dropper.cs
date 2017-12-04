using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{

	public Cow cow;
	public Transform dropPoint;

	private int cows;
	
	// Use this for initialization
	void Start ()
	{
		cows = StaticData.Cows;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DropCow()
	{
		Instantiate(cow, dropPoint.position, Quaternion.identity);
		var rigidBody = (Rigidbody2D) cow.GetComponent(typeof(Rigidbody2D));
		rigidBody.gravityScale = 1f;

		cows--;
	}
}
