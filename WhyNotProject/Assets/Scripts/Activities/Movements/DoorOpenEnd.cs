using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenEnd : MonoBehaviour
{
	public ManagerScene scener;
	public float delaySec = 1f;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			scener.DelayChange(delaySec, "EndScene");
		}
		
	}
}
