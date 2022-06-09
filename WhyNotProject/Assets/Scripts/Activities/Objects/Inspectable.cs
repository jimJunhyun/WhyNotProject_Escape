using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����� ��� : 
/// �̵�, ȸ�� �� ������ �����Ѵ�.
/// �������� ��ü�� �̵��� �����Ѵ�.
/// 
/// </summary>
[RequireComponent(typeof(Holdable))]
public class Inspectable : MonoBehaviour
{
    Holdable myHold;
	private void Awake()
	{
		myHold = GetComponent<Holdable>();
	}
	private void Update()
	{
		if (InspectManager.Instance.isInspecting && Input.GetKeyDown(InspectManager.Instance.InspectKey))
		{
			InspectManager.Instance.EndInspecting();
		}
		if (myHold.isHeld&&!InspectManager.Instance.isInspecting && Input.GetKeyDown(InspectManager.Instance.InspectKey))
		{
			Vector3 cameraMiddle = InspectManager.Instance.InspectCam.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
			cameraMiddle.z = InspectManager.Instance.inspectDist;
			transform.position = InspectManager.Instance.InspectCam.ScreenToWorldPoint(cameraMiddle);
			InspectManager.Instance.StartInspecting();
		}
		
	}
}
