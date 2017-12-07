using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropper : MonoBehaviour
{

	public GameObject cow;
	public Transform dropPoint;
	public Text cowText;
	private String beginText;

	private int cows;
	
	// Use this for initialization
	void Start ()
	{
		cows = StaticData.Cows;
		beginText = cowText.text;
		
		updateText();
	}

	void updateText()
	{
		cowText.text = cows + beginText;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool DropCow(bool goodCow)
	{
		Cow newCow = (Cow) Instantiate(cow, dropPoint.position, Quaternion.identity).GetComponent(typeof(Cow));
		cows--;
		
		newCow.goodCow = goodCow;
		newCow.lastCow = cows <= 0;
		
		var rigidBody = newCow.GetComponent<Rigidbody2D>();
		rigidBody.gravityScale = 1f;
		
		updateText();

		return cows <= 0;
	}
}
