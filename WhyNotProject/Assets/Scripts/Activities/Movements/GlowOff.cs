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

	public void On()
	{
		glow.GlowColor = Color.green;
	}
	public void Off()
	{
		glow.GlowColor = Color.black;
	}
}
