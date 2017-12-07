using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CowBox : MonoBehaviour
{

	public SceneController sceneController;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D enteredObject)
	{
		if (enteredObject.transform.GetComponent(typeof(Cow)))
		{
			var cow = enteredObject.transform.GetComponent(typeof(Cow)) as Cow;
			
			cow.inCage = true;

			if (checkAllCows())
			{
				Win();
			}
		}
	}

	private void OnTriggerExit2D(Collider2D enteredObject)
	{
		if (enteredObject.transform.GetComponent(typeof(Cow)))
		{
			var cow = enteredObject.transform.GetComponent(typeof(Cow)) as Cow;

			cow.inCage = false;
		}
	}

	private bool checkAllCows()
	{
		foreach (Transform child in transform)
		{
			if (child.transform.GetComponent(typeof(Cow)))
			{
				var cow = child.transform.GetComponent(typeof(Cow)) as Cow;

				if (cow.inCage == false)
				{
					return cow.inCage;
				}
			}
		}

		return true;
	}

	private int countCows()
	{
		int i = 0;
		foreach (Transform child in transform)
		{
			if (child.transform.GetComponent(typeof(Cow)))
			{
				i++;
			}
		}
		return i;
	}
	
	private void Win()
	{
		StaticData.Cows = countCows();
		sceneController.loadScene("Feed");
	}
}
