using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{

	private static int cows;

	public static int Cows
	{
		get
		{
			if (Application.isEditor && cows == 0)
			{
					return 4;
			}
			return cows;
		}
		set { cows = value; }
	}

	public static int BadFood { get; set; }
	public static int GoodFood { get; set; }

	public static void Reset()
	{
		Cows = 0;
		BadFood = 0;
		GoodFood = 0;
	}
}
