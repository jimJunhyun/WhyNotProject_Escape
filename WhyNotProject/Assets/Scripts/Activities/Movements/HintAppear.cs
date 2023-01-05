using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintAppear : MonoBehaviour
{
	[SerializeField] private InnerLight innerLight;
    SunRotation sunState;
	MeshRenderer rend;
	private void Awake()
	{
		sunState = GameObject.Find("Sun").GetComponent<SunRotation>();
		rend = GetComponent<MeshRenderer>();
	}
	private void Update()
	{
		if(sunState.IsNight && !innerLight.isLightOn)
		{
			rend.enabled = true;
		}
		else
		{
			rend.enabled = false;
		}
	}
}
