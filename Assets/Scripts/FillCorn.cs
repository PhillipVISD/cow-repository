using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FillCorn : MonoBehaviour
{

	public Transform cornParent;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.CompareTag("Corn"))
		{
			var renderer = other.transform.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
			renderer.enabled = true;

			if (checkAllCorn())
			{
				SceneManager.LoadScene("Process");
			}
		}
	}

	private bool checkAllCorn()
	{
		foreach (Transform child in cornParent)
		{
			if (child.CompareTag("Corn"))
			{
				var renderer = child.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
				if (renderer.enabled == false)
				{
					return false;
				}
			}
		}

		return true;
	}
}
