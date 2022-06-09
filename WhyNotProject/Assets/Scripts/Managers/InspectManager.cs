using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectManager : MonoBehaviour
{
    public static InspectManager Instance;
	public Image InspectPanel;
	public float inspectDist;
	public Camera InspectCam;
	[HideInInspector]
	public bool isInspecting;
	public KeyCode InspectKey;

	private void Awake()
	{
		Instance = this;
		InspectPanel.enabled = false;
		isInspecting = false;
	}
	public void StartInspecting()
	{
		Debug.Log("ASDF");
		isInspecting = true;
		InspectPanel.enabled = true;
	}
	public void EndInspecting()
	{
		Debug.Log("FDSA");
		isInspecting = false;
		InspectPanel.enabled = false;
	}
}
