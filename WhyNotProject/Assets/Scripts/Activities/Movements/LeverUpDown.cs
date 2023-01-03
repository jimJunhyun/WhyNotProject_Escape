using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverUpDown : MonoBehaviour
{
	public Light stageLight;
    int state = 2;
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
			state += 1;
			state %= 3;
			anim.SetInteger("State", state);
			if(state == 0)
			{
				stageLight.gameObject.SetActive(false);
			}
			else if(state == 1)
			{
				stageLight.gameObject.SetActive(true);
			}
			else
			{
				stageLight.gameObject.SetActive(true);
				stageLight.enabled = true;
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
