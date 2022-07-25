using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(GlowObjectCmd))]
public class Inspectable : MonoBehaviour
{
	RaycastHit hit;
	Collider myCol;
	int originLayer;
	Vector3 originPos;
	Quaternion originRot;

	bool currentInspected = false;

	private void Awake()
	{
		myCol = GetComponent<Collider>();
		originLayer = gameObject.layer;
		originPos = transform.position;
		originRot = transform.rotation;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && HoldManager.Instance.MouseCursorDetect(out hit))
		{
			if(hit.collider == myCol && !currentInspected)
			{
				gameObject.layer = 6;
				currentInspected = true;
				++InspectManager.Instance.InspectingNum;
			}
		}
		else if(Input.GetMouseButtonDown(1) && HoldManager.Instance.MouseCursorDetect(out hit))
		{
			if(hit.collider == myCol && currentInspected)
			{
				currentInspected = false;
				gameObject.layer = originLayer;
				transform.position = originPos;
				transform.rotation = originRot;
				--InspectManager.Instance.InspectingNum;
			}
		}
		Inspect();
	}
	void Inspect()
	{
		if (currentInspected)
		{
			GetInput();
		}
	}
	
	void GetInput()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		transform.Rotate(new Vector3(v, h, 0) * InspectManager.Instance.moveSpeed * Time.deltaTime, Space.World);
	}
}
