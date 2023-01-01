using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverUpDown : MonoBehaviour
{
	public Light stageLight;
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
				stageLight.gameObject.SetActive(false);
				state = false;
			}
			else
			{
				anim.SetBool("Up", false);
				stageLight.gameObject.SetActive(true);
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
