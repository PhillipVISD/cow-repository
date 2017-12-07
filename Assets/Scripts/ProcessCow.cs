using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessCow : MonoBehaviour
{

	public Transform foodSpawn;
	public Transform food;
	public Transform trash;
	public Transform particles;
	public AnimationClip killClip;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent(typeof(Cow)))
		{
			var cow = (Cow) other.GetComponent(typeof(Cow));

			StartCoroutine(dropFood(cow));

			if (particles != null)
			{
				Instantiate(particles, other.transform.position, Quaternion.identity, transform);
			}

//			Animation anim = other.gameObject.GetComponent<Animation>();
//			anim.clip = killClip;
//			anim.Play();
			cow.deathAnim();
		}
		
	}

	IEnumerator dropFood(Cow cow)
	{
		Result result;
		
		yield return new WaitForSeconds(2.0f);
		if (cow.goodCow)
		{
			result = (Result) Instantiate(food, foodSpawn.position, Quaternion.identity).GetComponent(typeof(Result));
		}
		else
		{
			result = (Result) Instantiate(trash, foodSpawn.position, Quaternion.identity).GetComponent(typeof(Result));
		}
		
		result.lastFood = cow.lastCow;
		result.goodFood = cow.goodCow;
	}
}
