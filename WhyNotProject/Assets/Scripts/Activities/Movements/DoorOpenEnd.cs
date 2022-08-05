using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
	public float delaySec = 1f;
	private void OnTriggerEnter(Collider other)
	{
		StartCoroutine(DelayEnd());
	}

	IEnumerator DelayEnd()
	{
		yield return new WaitForSeconds(delaySec);

	}
}
