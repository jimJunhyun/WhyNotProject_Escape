using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightGimmick : MonoBehaviour
{
	public GameObject pan;

	private Vector3 yPos;
	private Vector3 originPos;
	public float yMin = 0.5f;
	public int maxObjectCount = 3;
	private int objectCount = 0;

	private void Start()
	{
		originPos = pan.transform.position;
		yPos = new Vector3(originPos.x, originPos.y - yMin, originPos.z);
	}

	private void Update()
	{
		yPos = new Vector3(originPos.x, originPos.y - yMin * objectCount / maxObjectCount, originPos.z);
	}

	private void FixedUpdate() 
	{
		if (objectCount > 0)
		{
			pan.transform.position = Vector3.MoveTowards(pan.transform.position, yPos, Time.deltaTime / 10);
		}
		else
		{
			pan.transform.position = Vector3.MoveTowards(pan.transform.position, originPos, Time.deltaTime / 5);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != pan)
		{
			other.transform.SetParent(pan.transform);
			++objectCount;
			Debug.Log(objectCount);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject != pan)
		{
			other.transform.SetParent(null);
			other.transform.localScale = new Vector3(20.595f, 20.595f, 20.595f);
			--objectCount;
		}
	}
}
