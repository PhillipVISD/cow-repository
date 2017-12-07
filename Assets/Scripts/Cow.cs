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
	
	public bool goodCow = true;
	public bool lastCow = false;

	public Animator animator;

	public Rigidbody2D rigidbody;
	public Collider2D collider;

	// Use this for initialization
	void Start ()
	{

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

	public void deathAnim()
	{
		animator.enabled = true;
		stopInteractions();
		animator.SetBool("Dying", true);
		animator.GetBehaviour<CowAnimator>().cow = this;
	}

	public void killCow()
	{
		if (transform.parent != null)
		{
			Destroy(transform.parent.gameObject);
		}
		Destroy(gameObject);
	}

	public void stopInteractions()
	{
		collider.enabled = false;
		Destroy(rigidbody);
	}
}
