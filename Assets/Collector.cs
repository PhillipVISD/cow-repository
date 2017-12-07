using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent(typeof(Result)))
		{
			Destroy(other.gameObject);

			Result result = (Result) other.GetComponent(typeof(Result));

			if (result.lastFood)
			{
//				GameManager.LoadScene("Deliver");
				GameManager.restart();
			}

			if (result.goodFood)
			{
				StaticData.GoodFood++;
			}
			else
			{
				StaticData.BadFood++;
			}
		}
	}
}
