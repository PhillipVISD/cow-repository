using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{

	public bool move = true;

	public float speed = 1f;
	
	private List<Transform> objects = new List<Transform>();
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (move)
		{
			foreach (Transform cow in objects)
			{
				cow.transform.Translate(speed * Time.deltaTime, 0f, 0f);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Pointer"))
		{
			objects.Add(other.transform);
		}
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
		
		if (!other.CompareTag("Pointer"))
		{
			objects.Remove(other.transform);
		}
	}

	public void stopConveyor()
	{
		move = false;
	}
}
