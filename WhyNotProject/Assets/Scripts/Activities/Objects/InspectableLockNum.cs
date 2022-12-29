using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GlowObjectCmd))]
public class InspectableLockNum : MonoBehaviour
{
	RaycastHit hit;
	Collider myCol;
	int originLayer;
	Vector3 originPos;
	float vRot;

	public Vector3 angle = Vector3.zero;

	bool currentInspected = false;

	LockManager lockManager;

	private void Awake()
	{
		lockManager = GetComponentInParent<LockManager>();
		myCol = GetComponent<Collider>();
		angle = transform.eulerAngles;
		angle.y = -180f + 36f;
		originLayer = gameObject.layer;
		originPos = transform.position;
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -54f);
	}

	private void Start()
	{
		lockManager.OnUnlocked.AddListener(SetOff);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && HoldManager.Instance.MouseCursorDetect(out hit))
		{
			if (hit.collider == myCol && !currentInspected && !OptionUI.instance.IsPointerOverUIObject())
			{
				gameObject.layer = 6;
				currentInspected = true;
				++InspectManager.Instance.InspectingNum;
			}

		}
		else if (Input.GetMouseButtonDown(1) && HoldManager.Instance.MouseCursorDetect(out hit))
		{
			if (currentInspected && !OptionUI.instance.IsPointerOverUIObject())
			{
				currentInspected = false;
				gameObject.layer = originLayer;
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
		if (Input.GetMouseButton(0))
		{
			vRot = Input.GetAxis("Mouse X");
		}
		if (Input.GetMouseButtonUp(0))
		{
			vRot = 0;
		}
		angle += new Vector3(0, -vRot) * 5f * InspectManager.Instance.moveSpeed * Time.deltaTime;
		if (angle.y >= 180)
		{
			angle.y = -180;
		}
		if (angle.y < -180)
		{
			angle.y = 180;
		}
		transform.eulerAngles = new Vector3(-180, 36 * Mathf.Floor(angle.y / 36f) + 18);
	}

	public void SetOff()
	{
		if (currentInspected)
		{
			currentInspected = false;
			gameObject.layer = originLayer;
			--InspectManager.Instance.InspectingNum;
		}
		lockManager.OnUnlocked.RemoveListener(SetOff);
		this.enabled = false;
	}
}
