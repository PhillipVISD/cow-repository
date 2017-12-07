using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Facility : MonoBehaviour
{

	public SceneController sceneController;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			// Object is player
			
			// Win
			
//			GameManager.win();
			sceneController.loadScene("Menu");
		}
	}
}
