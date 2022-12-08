using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressKeyChecker : MonoBehaviour
{
    public string Key;
    public UnityEvent OnMatched;
	public bool checking = false;
	
	PressKeyRecorder curKey;
	private void Awake()
	{
		curKey = GetComponent<PressKeyRecorder>();
	}
	private void Update()
	{
		if (checking)
		{
			CheckKey();
		}
		
	}
	public void StartChecking()
	{
		checking = true;
	}
	public void EndChecking(bool isReset)
	{
		checking = false;
		if (isReset)
		{
			curKey.ResetKey();
		}
	}
	void CheckKey()
	{
		if(curKey.recorded == Key)
		{
			OnMatched?.Invoke();
			curKey.ResetKey();
		}
	}
	public void TempFunc()
	{
		Debug.Log("TmpTmptmp");
	}
}
