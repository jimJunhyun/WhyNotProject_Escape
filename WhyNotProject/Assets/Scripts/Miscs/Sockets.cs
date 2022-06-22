using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sockets : MonoBehaviour
{
	public List<Holdable> keys = new List<Holdable>(); //���Ͽ� �� �� �ִ� ��ü��
	public UnityEvent OnMatched;
	Holdable keyInfo;
	private void OnTriggerStay(Collider collision)
	{
		if(!collision.gameObject.TryGetComponent(out keyInfo))
		{
			throw new System.Exception();
		}
		else if (keys.Contains(keyInfo) && !keyInfo.isHeld && !keyInfo.isPlaced)
		{
			keyInfo.Place(transform.position);
		}
	}
}