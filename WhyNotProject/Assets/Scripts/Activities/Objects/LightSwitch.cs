using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public bool isOn;
	Animator myAnim;
	void Awake()
	{
		myAnim = GetComponent<Animator>();
	}
	public void LeverSwitch()
	{
		if (LightRule.instance.isUsable)
		{
			isOn = !isOn;
			myAnim.SetBool("isOn", isOn);
		}
		
	}
}
