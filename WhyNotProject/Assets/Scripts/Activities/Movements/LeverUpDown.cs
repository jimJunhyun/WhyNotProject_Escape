using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverUpDown : MonoBehaviour
{
    [HideInInspector] public int state = 1;
	[HideInInspector] public bool isActive = false;
	Animator anim;
	private void Awake()
	{
		anim = GetComponent<Animator>();
		anim.SetInteger("State", state);
	}
	public void Trigger()
	{
		if (isActive)
		{
			state += 1;
			state %= 3;
			anim.SetInteger("State", state);
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
