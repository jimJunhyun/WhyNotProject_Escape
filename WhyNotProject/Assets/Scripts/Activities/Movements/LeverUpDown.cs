using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverUpDown : MonoBehaviour
{
    bool state = true;
	Animator anim;
	private void Awake()
	{
		anim = GetComponent<Animator>();
	}
	public void Trigger()
	{
		if (state)
		{
			anim.SetTrigger("Down");
			state = false;
		}
		else
		{
			anim.SetTrigger("Up");
			state = true;
		}
	}
}
