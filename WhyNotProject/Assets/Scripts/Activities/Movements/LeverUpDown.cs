using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverUpDown : MonoBehaviour
{
	public Light stageLight;
	public Material lightMat;
	SunRotation sunState;
	HintAppear hint;
    int state = 1;
	bool isActive = false;
	Animator anim;
	private void Awake()
	{
		sunState = GameObject.Find("Sun").GetComponent<SunRotation>();
		hint = GameObject.Find("HintLetter").GetComponent<HintAppear>();
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
				lightMat.EnableKeyword("_EMISSION");
				stageLight.enabled = true;
				hint.lightState = true;
			}
			if(state == 1)
			{
				stageLight.gameObject.SetActive(true);
				hint.lightState = true;
				if (sunState.IsNight)
				{
					lightMat.EnableKeyword("_EMISSION");
				}
				else
				{
					lightMat.DisableKeyword("_EMISSION");
				}
			}
			if(state == 0)
			{
				hint.lightState = false;
				stageLight.gameObject.SetActive(false);
				lightMat.DisableKeyword("_EMISSION");
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
