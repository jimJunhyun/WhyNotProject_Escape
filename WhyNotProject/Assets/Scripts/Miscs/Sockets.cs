using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sockets : MonoBehaviour
{
	public List<Holdable> keys = new List<Holdable>(); //���Ͽ� �� �� �ִ� ��ü��
	Holdable keyInfo;
	private void OnTriggerStay(Collider collision)
	{
		if(!collision.gameObject.TryGetComponent(out keyInfo))
		{
			throw new System.Exception();
		}
		if (keys.Contains(keyInfo) && !keyInfo.isHeld)
		{
			keyInfo.Place(transform.position);
		}
	}

}
