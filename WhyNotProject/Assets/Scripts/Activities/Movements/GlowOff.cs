using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowOff : MonoBehaviour
{
	GlowObjectCmd glow;
	private void Awake()
	{
		glow = GetComponent<GlowObjectCmd>();
	}

	public void Off(float animLeng)
	{
		StartCoroutine(ContinuousOff(animLeng));
	}

	IEnumerator ContinuousOff(float animLen)
	{ 
		yield return new WaitForSeconds(animLen);
		glow.enabled = false;
		
	}
}
