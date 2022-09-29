using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
	public List<Collider> door;
    public void OpenDoor()
	{
		foreach (var item in door)
		{
			item.isTrigger = true;
		}
	}
}
