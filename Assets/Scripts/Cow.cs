using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{

	public Transform player;
	public float speed;

	public bool inCage;
	public bool chasePlayer = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{
		if (chasePlayer)
		{
			var distance = Vector2.Distance(transform.position, player.position);

			if (distance <= 3)
			{
				rotateAway();
			
				transform.Translate(Vector3.left * speed * Time.deltaTime);
			}
		}
	}

	void rotateAway()
	{
		// Get Angle in Radians
		float AngleRad = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x);
		// Get Angle in Degrees
		float AngleDeg = (180 / Mathf.PI) * AngleRad;
		// Rotate Object
		transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
	}
}
