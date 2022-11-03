using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverReverse : MonoBehaviour
{
    bool state = false;
	Animator myAnim;
	private void Awake()
	{
		myAnim = GetComponent<Animator>();
	}
	public void UpdateState()
	{
		state = !state;
		myAnim.SetBool("isOn", state);
	}
}
