using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCow : MonoBehaviour
{

	public Transform spawnPoint;

	public GameObject cow;

	public CowBox cowParent;

	public Transform player;

	public int amountOfCows;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DropCows()
	{
		for (int i = 0; i < amountOfCows; i++)
		{
			GameObject newObject = Instantiate(cow, 
				new Vector3(spawnPoint.transform.position.x + i,
					spawnPoint.transform.position.y,
					spawnPoint.transform.position.z),
				Quaternion.identity);

			var newCow = newObject.GetComponent(typeof(Cow)) as Cow;
			
			newCow.player = player;
			newCow.transform.parent = cowParent.transform;
			newCow.chasePlayer = true;
		}
	}
}
