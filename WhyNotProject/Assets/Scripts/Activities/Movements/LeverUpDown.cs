using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverUpDown : MonoBehaviour
{
    bool state = true;
	bool isActive = false;
	Animator anim;
	private void Awake()
	{
		anim = GetComponent<Animator>();
	}
	public void Trigger()
	{
		if (isActive)
		{
			if (state)
			{
				anim.SetBool("Up", true);
				state = false;
			}
			else
			{
				anim.SetBool("Up", false);
				state = true;
			}
		}
		
	}
	public void Disactivate()
	{
		isActive = false;
	}
	public void Activate()
	{
		isActive = true;
	}
}
