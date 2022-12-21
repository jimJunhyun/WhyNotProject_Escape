using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRule : MonoBehaviour
{
	public static LightRule instance;
	List<LightState> Lights = new List<LightState>();
	public List<LightSwitch> Switches = new List<LightSwitch>();
	public bool isUsable;
	bool allMatch;
	PressKeyRecorder prMan;
	const string SOLVEMARK = "Solved!";

	bool interable = true;

	private void Awake()
	{
		instance = this;
		prMan = GetComponent<PressKeyRecorder>();
		GetComponentsInChildren(Lights);
		GetComponentsInChildren(Switches);
	}

	private void Update()
	{
		if (!allMatch)
		{
			for (int i = 0; i < Lights.Count - 1; i++)
			{
				if (i == 0)
				{
					allMatch = true;
				}
				allMatch = Lights[i].isLighted && allMatch;
			}
		}
		if(allMatch && interable)
		{
			prMan.AddKey(SOLVEMARK);
			interable = false;
		}
	}

	public void EnableLight()
	{
		isUsable = true;
	}
	public void DisableLight()
	{
		isUsable = false;
	}
	public void TempFunc()
	{
		Debug.Log("OpenedBox");
	}
}
