using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
	public List<int> connectedNo;
	public LightRule box;
    bool isOn;

	bool changed;
	bool direction = true; // 일반상태

	public void ReverseDir()
	{
		direction = !direction;
		if (isOn)
		{
			box.OnOffLight(connectedNo.ToArray());
			changed = true;
		}
		
		if (direction)
		{
			connectedNo[1] = connectedNo[0] + 2;
		}
		else
		{
			connectedNo[1] = connectedNo[0] - 2;
		}
		
	}

	public void LeverSwitch()
	{
		isOn = !isOn;
		changed = true;
	}

	private void Update()
	{
		if (changed)
		{
			box.OnOffLight(connectedNo.ToArray());
			
			changed = false;
		}
	}
}
