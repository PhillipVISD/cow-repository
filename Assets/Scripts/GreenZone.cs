using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenZone : MonoBehaviour
{

	public Transform pointer;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Pointer"))
		{
			pointer = other.transform;
		}
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Pointer"))
		{
			pointer = null;
		}
	}

	public bool pointerInGreen()
	{
		return pointer != null;
	}
}
