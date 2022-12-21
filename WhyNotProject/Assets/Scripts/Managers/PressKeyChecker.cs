using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressKeyChecker : MonoBehaviour
{
    public string Key;
    public UnityEvent OnMatched;
	public bool isCommand;
	public bool checking = false;
	
	PressKeyRecorder curKey;
	private void Awake()
	{
		curKey = GetComponent<PressKeyRecorder>();
	}
	private void Update()
	{
		if (checking && (isCommand ||(!isCommand && curKey.coinNum > 0)))
		{
			CheckKey();
		}
		
	}
	public void StartChecking()
	{
		checking = true;
	}
	public void EndChecking(bool isReset) //이걸 전화기 내리면 사용
	{
		checking = false;
		if (isReset)
		{
			curKey.ResetKey();
		}
	}
	void CheckKey()
	{
		if(curKey.recorded != "")
		{
			if (curKey.recorded == Key)
			{
				OnMatched?.Invoke();
				if (!isCommand)
				{
					curKey.ResetKey();
					curKey.UseCoin();
				}
			}
			if (isCommand && curKey.recorded[curKey.recorded.Length - 1] == '#')
			{
				curKey.ResetKey();
			}
		}
		
	}
	public void TempFunc()
	{
		Debug.Log("TmpTmptmp");
	}
}
