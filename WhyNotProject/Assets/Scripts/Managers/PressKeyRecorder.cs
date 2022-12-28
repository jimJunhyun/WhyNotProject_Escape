using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyRecorder : MonoBehaviour
{
	public string recorded;
	public bool recording = true;
	public int coinNum = 0;
    public void AddKey(string KeyInfo)
	{
		if (recording)
		{
			recorded += KeyInfo;
		}
		
	}
	public void ResetKey()
	{
		recorded = "";
	}
	public void RecordStart()
	{
		recording= true;
	}
	public void RecordEnd()
	{
		recording = false;
	}
	public void AddCoin()
	{
		++coinNum;
	}
	public void UseCoin()
	{
		++coinNum;
	}
}
