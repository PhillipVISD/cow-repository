using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class Player : MonoBehaviour
{

	public float speed = 1;
	public Transform sprites;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3(CnInputManager.GetAxis("Horizontal") * Time.deltaTime * speed,
			CnInputManager.GetAxis("Vertical") * Time.deltaTime * speed, 0f);
		
		var dir = (transform.position + movement) - transform.position;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		sprites.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
		transform.Translate(movement);
	}
	
	
}
