using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockManager : MonoBehaviour
{
	LockNum[] numbers;
	public string curNum;
	public string targetNum;

	public UnityEvent OnUnlocked;

	private void Awake()
	{
		numbers = GetComponentsInChildren<LockNum>();
	}

	private void Update()
	{
		curNum = ($"{numbers[0].num}{numbers[1].num}{numbers[2].num}{numbers[3].num}");
		if (curNum.Equals(targetNum))
		{
			OnUnlocked?.Invoke();
			this.enabled = false;
		}
	}
}
