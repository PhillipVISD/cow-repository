using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Generator : MonoBehaviour
{	
	public GameObject road;
	public GameObject roadLeft;
	public GameObject roadRight;
	public GameObject intersection;

	public GameObject[] buildings;
	public List<GenNode> nodes;

	public GameObject truck;

	public float genLimit;

	private GameObject genObject;
	
	// Use this for initialization
	void Start ()
	{
		GenNode node = CreateNode(new Vector3(0, 0, 0));
		nodes.Add(node);
		
	}

	private int nodeId = 0;

	GenNode CreateNode(Vector3 position)
	{
		GameObject newNode = new GameObject("Node " + nodeId.ToString());
		nodeId++;

		newNode.AddComponent(typeof(GenNode));
		GenNode node = newNode.GetComponent<GenNode>();
		return node;
	}

	bool WithinNode(Vector3 checkPosition, float range)
	{
		foreach (GenNode node in nodes)
		{
			if (Vector3.Distance(checkPosition, node.transform.position) > genLimit)
			{
				return false;
			}
		}
		return true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!WithinNode(truck.transform.position, genLimit))
		{
//			float angle = AngleBetweenVector2(truck.transform.position, )
		}
	}
	
	private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
	{
		Vector2 diference = vec2 - vec1;
		float sign = (vec2.y < vec1.y)? -1.0f : 1.0f;
		return Vector2.Angle(Vector2.right, diference) * sign;
	}
}
