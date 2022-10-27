using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PostWeight : MonoBehaviour
{
	public int maxWeight = 10;
	public Transform parentObject;
	public Vector3 basePosition;
	public Vector3 maxWeightPosition;
	public List<Collider> objs = new List<Collider>();
	//public LayerMask interactableLayer;

	private Vector3 moveAmount;
	[SerializeField] int currentWeight = 0;

	public Ease moveEase;

	private void Awake()
	{
		parentObject = transform.parent;
		basePosition = parentObject.position;

		moveAmount = maxWeightPosition - parentObject.position;
	}

	private void CheckWeight() //무게를 확인하여 위치 조정
	{
		currentWeight = 0;
		foreach (Collider col in objs)
		{
			currentWeight += col.GetComponent<Holdable>().objWeight;
			currentWeight = Mathf.Clamp(currentWeight, 0, maxWeight);
		}

		parentObject.DOMoveY(basePosition.y + moveAmount.y * (float)(currentWeight / (float)maxWeight), 1f).SetEase(moveEase, 1f);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 7)
		{
			other.transform.SetParent(parentObject);
			objs.Add(other);
			CheckWeight();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 2 || other.gameObject.layer == 7)
		{
			other.transform.SetParent(null);
			objs.Remove(other);
			CheckWeight();
		}
	}
}
