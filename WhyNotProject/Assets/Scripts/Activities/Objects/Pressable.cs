using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GlowObjectCmd))]
public class Pressable : MonoBehaviour
{
    public PressManager manager;
    public string KeyInfo;

	RaycastHit hit;
	Collider myCol;

	private void Awake()
	{
		myCol = GetComponent<Collider>();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && HoldManager.Instance.MouseCursorDetect(out hit))
		{
			if (hit.collider == myCol)
			{
				manager.AddKey(KeyInfo);
			}
		}
	}
}
