using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverUpDown : MonoBehaviour
{
	public Light stageLight;
	public Material lightMat;
    int state = 2;
	bool isActive = false;
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
			if(state == 2)
			{
				stageLight.gameObject.SetActive(true);
				stageLight.enabled = true;
			}
			if(state == 1)
			{
				stageLight.gameObject.SetActive(true);
			}
			if(state == 0)
			{
				stageLight.gameObject.SetActive(false);
				
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
