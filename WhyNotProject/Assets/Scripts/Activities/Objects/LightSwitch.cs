using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public bool isOn;
	public void LeverSwitch()
	{
		isOn = !isOn;
	}
}
