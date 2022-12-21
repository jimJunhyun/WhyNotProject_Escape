using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyRecorder : MonoBehaviour
{
	public string recorded;
	public bool recording = true;
    public void AddKey(string KeyInfo)
	{
		recorded += KeyInfo;
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
}
