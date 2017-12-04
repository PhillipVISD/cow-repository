using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{

	private static int cows;

	public static int Cows
	{
		get { return cows; }
		set { cows = value; }
	}
}
