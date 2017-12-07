using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
	public Image black;
	public Animator anim;

	public bool fadeInOnStart = true;
	
	// Use this for initialization
	void Start () {
		anim.SetBool("FadeInOnStart", fadeInOnStart);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loadScene(String scene)
	{
		StartCoroutine(Fading(scene));
	}

	IEnumerator Fading(String scene)
	{
		anim.SetBool("Fade", true);
		yield return new WaitUntil(() => black.color.a == 1);
		SceneManager.LoadScene(scene);
	}
}
