using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRule : MonoBehaviour
{
	List<LightState> Lights = new List<LightState>();
	bool allMatch;
	PressManager prMan;

	bool changedStatus;
	bool interable = true;

	private void Awake()
	{
		prMan = GetComponent<PressManager>();
		GetComponentsInChildren(Lights);
	}

	private void Update()
	{
		if (!allMatch && changedStatus)
		{
			for (int i = 0; i < Lights.Count - 1; i++)
			{
				if (i == 0)
				{
					allMatch = true;
				}
				allMatch = Lights[i].isLighted && allMatch;
			}
			changedStatus = false;
		}
		if(allMatch && changedStatus && interable)
		{
			prMan.AddKey(prMan.Key);
			changedStatus = false;
			interable = false;
		}
	}

	public void TempFunc()
	{
		Debug.Log("OpenedBox");
	}

	public void OnOffLight(params int[] indexes)
	{
		if (interable)
		{
			for (int i = 0; i < indexes.Length; i++)
			{
				try
				{
					Lights[indexes[i]].isLighted = !Lights[indexes[i]].isLighted;
					if (Lights[indexes[i]].isLighted)
					{
						Lights[indexes[i]].myMat.EnableKeyword("_EMISSION");
					}
					else
					{
						Lights[indexes[i]].myMat.DisableKeyword("_EMISSION");
					}
					changedStatus = true;
				}
				catch (ArgumentOutOfRangeException outOfArr)
				{
					// do nothing
				}

			}
		}
		
		
		
	}
}
