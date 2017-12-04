using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessCow : MonoBehaviour
{

	public Transform foodSpawn;
	public Transform food;

	private void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);

		var newFood = Instantiate(food, foodSpawn.position, Quaternion.identity);
	}
}
