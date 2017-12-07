using System.Collections;
using System.Collections.Generic;
using CnControls;
using UnityEngine;

public class Truck : MonoBehaviour
{

	public float speed;
	public float rotateSpeed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3(CnInputManager.GetAxis("Vertical") * Time.deltaTime * speed, 0f, 0f);
		
		transform.Rotate(Vector3.forward, (CnInputManager.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed * CnInputManager.GetAxis("Vertical")));
		
		transform.Translate(movement);
	}
}
