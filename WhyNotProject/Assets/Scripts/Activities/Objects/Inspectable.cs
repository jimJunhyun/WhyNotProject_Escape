using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 들었을 경우 : 
/// 이동, 회전 등 조작을 정지한다.
/// 조사중인 물체의 이동을 정지한다.
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
