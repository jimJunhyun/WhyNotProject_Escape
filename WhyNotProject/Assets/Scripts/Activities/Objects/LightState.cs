using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightState : MonoBehaviour
{
    public bool isLighted = false;
    public Material myMat;

	private void Awake()
	{
		myMat = GetComponent<MeshRenderer>().material;
	}
}
