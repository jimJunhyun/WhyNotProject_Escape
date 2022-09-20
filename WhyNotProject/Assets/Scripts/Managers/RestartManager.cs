using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartManager : MonoBehaviour
{
	public ManagerScene scener;
	// Start is called before the first frame update
	private void Awake()
	{
		scener.DelayChange(1.5f, "StartScene");
	}
}
