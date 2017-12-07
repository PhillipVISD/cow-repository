using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using Random = UnityEngine.Random;

public class Cow : MonoBehaviour
{

	public Transform player;
	public float speed;

	public bool inCage;
	public bool chasePlayer = false;
	
	public bool goodCow = true;
	public bool lastCow = false;

	public bool wander = false;
	public float distance = 0;
	public Quaternion angle = Quaternion.identity;

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
		if (wander)
		{
			if (distance <= 0)
			{
				distance = Random.Range(0.8f, 5.0f);
				angle = Random.rotation;
				
				if (Random.Range(0.0f, 1.0f) > 0.5f)
				{
					StartCoroutine(Sleep(Random.Range(0.4f, 2.8f)));
				}
			}

			float moveAngle = Mathf.MoveTowardsAngle(angle.eulerAngles.z, transform.eulerAngles.z, speed * Time.deltaTime * 50);
			
			transform.eulerAngles = new Vector3(0, 0, moveAngle);
			
			
			if (Math.Abs(transform.eulerAngles.z - moveAngle) < 0.1f)
			{
				distance -= speed * Time.deltaTime;
				transform.Translate(Vector3.left * speed * Time.deltaTime);
			}
		}
	}

	IEnumerator Sleep(float time)
	{
		wander = false;
		yield return new WaitForSeconds(time);
		wander = true;
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
