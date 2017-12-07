using System.Collections;
using System.Collections.Generic;
using CnControls;
using UnityEngine;

public class Truck : MonoBehaviour
{

	public float maxSpeed = 100f;
	public float accelerationSpeed = 0.25f;
	public float deceleration = 0.5f;
	public float rotateSpeed;
	public float speed = 0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	
	// Update is called once per frame
	void Update ()
	{
		float acceleration = 0f;
		if (Input.GetAxis("Vertical") != 0)
		{
			acceleration = CnInputManager.GetAxis("Vertical") * accelerationSpeed;


		}
		else
		{
			acceleration = deceleration * (-1) * speed;
		}
		
		speed += acceleration;

		if (speed > maxSpeed)
		{
			speed = maxSpeed;
		}
			
		Vector3 movement = new Vector3(speed * Time.deltaTime, 0f, 0f);
//		Vector3 movement = new Vector3(CnInputManager.GetAxis("Vertical") * Time.deltaTime * acceleration, 0f, 0f);

		if (speed > 4)
		{
			transform.Rotate(Vector3.forward, (CnInputManager.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed * (4/speed)));
		}
		else if (speed > 1)
		{
			transform.Rotate(Vector3.forward, (CnInputManager.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed));
		}
		else
		{
			transform.Rotate(Vector3.forward, (CnInputManager.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed * speed));
		}
		
		transform.Translate(movement);
	}
}
