using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCows : MonoBehaviour
{

	public Cow cow;

	public Transform spawnpoint;

	// Use this for initialization
	void Start ()
	{
		int cows = StaticData.Cows;

		for (int i = 0; i < cows; i++)
		{
			var newCow = Instantiate(cow, new Vector3(spawnpoint.position.x + i, spawnpoint.position.y, spawnpoint.position.z),
				Quaternion.identity);

			Cow cowComp = newCow.GetComponent<Cow>();
			cowComp.wander = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
