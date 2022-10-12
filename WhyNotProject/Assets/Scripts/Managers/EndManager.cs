using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
	public Collider door;
    public void OpenDoor()
	{
		door.isTrigger = true;
	}
}
