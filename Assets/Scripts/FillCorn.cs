using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FillCorn : MonoBehaviour
{

	public SceneController sceneController;

	public Transform cornParent;
	private bool canFill = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.CompareTag("Corn") && canFill)
		{
			var renderer = other.transform.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;

			if (!renderer.enabled)
			{
				renderer.enabled = true;
				StartCoroutine(FillDelay(0.5f));
				
				if (checkAllCorn())
				{
					sceneController.loadScene("Process");
				}
			}
		}
	}

	IEnumerator FillDelay(float time)
	{
		canFill = false;
		yield return new WaitForSeconds(time);
		canFill = true;
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
