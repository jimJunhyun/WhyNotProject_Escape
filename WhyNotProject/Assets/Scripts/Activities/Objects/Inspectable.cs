using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(GlowObjectCmd))]
public class Inspectable : MonoBehaviour
{
	public UnityEvent AdditionalInspect;

	RaycastHit hit;
	Collider[] myColsArr;
	int originLayer;
	Vector3 originPos;
	Quaternion originRot;
	float h;
	float v;

	bool currentInspected = false;

	private void Awake()
	{
		myColsArr = GetComponents<Collider>();
		originLayer = gameObject.layer;
		originPos = transform.position;
		originRot = transform.rotation;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && HoldManager.Instance.MouseCursorDetect(out hit))
		{
			for (int i = 0; i < myColsArr.Length; i++)
			{
				if(hit.collider == myColsArr[i] && !currentInspected && !OptionUI.instance.IsPointerOverUIObject())
				{
					gameObject.layer = 6;
					currentInspected = true;
					++InspectManager.Instance.InspectingNum;
				}
				else if(hit.collider == myColsArr[i] && currentInspected)
				{
					AdditionalInspect?.Invoke();
				}
			}
			
		}
		else if(Input.GetMouseButtonDown(1) && HoldManager.Instance.MouseCursorDetect(out hit))
		{
			for (int i = 0; i < myColsArr.Length; i++)
			{
				if(hit.collider == myColsArr[i] && currentInspected && !OptionUI.instance.IsPointerOverUIObject())
				{
					currentInspected = false;
					gameObject.layer = originLayer;
					transform.position = originPos;
					transform.rotation = originRot;
					--InspectManager.Instance.InspectingNum;
				}
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
		if (Input.GetMouseButton(0))
		{
			v = Input.GetAxis("Mouse X");
			h = Input.GetAxis("Mouse Y");
		}
		if (Input.GetMouseButtonUp(0))
		{
			h = 0;
			v = 0;
		}
		

		transform.Rotate(new Vector3(h, v) * InspectManager.Instance.moveSpeed * Time.deltaTime, Space.World);
	}
}
