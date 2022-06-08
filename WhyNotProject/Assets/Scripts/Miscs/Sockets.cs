using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sockets : MonoBehaviour
{
	public List<Holdable> keys = new List<Holdable>(); //소켓에 들어갈 수 있는 물체들
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
