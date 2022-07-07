using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightGimmick : MonoBehaviour //감지 물체에 삽입
{
	[Tooltip("움직일 물체")]
	public GameObject pan;

	private Vector3 yPos;
	private Vector3 originPos;
	[Tooltip("줄어드는 y값")]
	public float yMin = 0.5f;
	public int fullWeight;
	private int objectWeight = 0;

	private void Start()
	{
		originPos = pan.transform.position;
		yPos = new Vector3(originPos.x, originPos.y - yMin, originPos.z);
	}

	private void Update()
	{
		yPos = new Vector3(originPos.x, originPos.y - yMin * objectWeight / fullWeight, originPos.z);
	}

	private void FixedUpdate() 
	{
		if (objectWeight > 0)
		{
			pan.transform.position = Vector3.Lerp(pan.transform.position, yPos, Time.deltaTime / 1);
		}
		else
		{
			pan.transform.position = Vector3.Lerp(pan.transform.position, originPos, Time.deltaTime / 2);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != pan && other.gameObject.GetComponent<Holdable>() != null)
		{
			other.transform.SetParent(pan.transform);
			objectWeight += other.gameObject.GetComponent<Holdable>().weight;
			Debug.Log(objectWeight);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject != pan && other.gameObject.GetComponent<Holdable>() != null)
		{
			other.transform.SetParent(null);
			other.transform.localScale = new Vector3(20.595f, 20.595f, 20.595f);
			objectWeight -= other.gameObject.GetComponent<Holdable>().weight;
		}
	}
}
