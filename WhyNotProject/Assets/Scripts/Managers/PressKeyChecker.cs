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
	public int coinInserted;
	
	PressKeyRecorder curKey;
	private void Awake()
	{
		curKey = GetComponent<PressKeyRecorder>();
	}
	private void Update()
	{
		if (checking && (isCommand ||(!isCommand && coinInserted > 0)))
		{
			CheckKey();
		}
		
	}
	public void StartChecking()
	{
		checking = true;
	}
	public void EndChecking(bool isReset) //�̰� ��ȭ�� ������ ���
	{
		checking = false;
		if (isReset)
		{
			curKey.ResetKey();
		}
	}
	public void AddCoin()
	{
		coinInserted += 1;
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
					coinInserted -= 1;
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