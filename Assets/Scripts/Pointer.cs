using System.Collections;
using System.Collections.Generic;
using CnControls;
using UnityEngine;

public class Pointer : MonoBehaviour
{

	public Animation animation;
	public GreenZone greenZone;
	public Dropper dropper;

	private bool finished = false;
	private bool inAnim = false;

	private Vector3 start;
	
	// Use this for initialization
	void Start ()
	{
		start = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (CnInputManager.GetButtonDown("Jump") && !finished && !inAnim)
		{
			animation.Stop();
			if (greenZone.pointerInGreen())
			{
				Debug.Log("In green");
				finished = dropper.DropCow(true);
			}
			else
			{
				Debug.Log("In red");
				finished = dropper.DropCow(false);
			}
			if (!finished) StartCoroutine(Restart());
		}
	}

	IEnumerator Restart()
	{
		inAnim = true;
		yield return new WaitForSeconds(0.5f);
		iTween.MoveTo(this.gameObject, start, 0.5f);
		yield return new WaitForSeconds(0.5f);
		animation.Play();
		inAnim = false;
	}
}
