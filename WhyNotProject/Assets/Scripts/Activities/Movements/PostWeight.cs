using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostWeight : MonoBehaviour
{
	public int maxWeight = 10;
	public Transform parentObject;
	public Vector3 basePosition;
	public Vector3 maxWeightPosition;
	public List<Collider> objs = new List<Collider>();
	public LayerMask interactableLayer;

	[SerializeField] private Vector3 moveAmount;

	[SerializeField] int currentWeight = 0;

	private void Awake()
	{
		parentObject = transform.parent;
		basePosition = parentObject.position;

		moveAmount = maxWeightPosition - parentObject.position;
	}

	private void Update()
	{
		CheckWeight();
	}

	private void CheckWeight()
	{
		currentWeight = 0;
		foreach (Collider col in objs)
		{
			currentWeight += col.GetComponent<Holdable>().objWeight;
			currentWeight = Mathf.Clamp(currentWeight, 0, maxWeight);
		}

		parentObject.position = Vector3.Lerp(parentObject.position, basePosition + moveAmount * (float)(currentWeight / (float)maxWeight), 0.01f);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 7)
		{
			other.transform.SetParent(parentObject);
			objs.Add(other);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 2 || other.gameObject.layer == 7)
		{
			other.transform.SetParent(null);
			objs.Remove(other);
		}
	}
}
