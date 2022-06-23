using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertCoin : MonoBehaviour
{
	Animator anim;
	public string TriggerName;
	private void Awake()
	{
		anim = GetComponent<Animator>();
	}
	public void StartAnim()
	{
		anim.SetTrigger(TriggerName);
	}
	
}
