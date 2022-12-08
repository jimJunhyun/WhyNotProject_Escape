using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyRecorder : MonoBehaviour
{
	public string recorded;
    public void AddKey(string KeyInfo)
	{
		recorded += KeyInfo;
	}
	public void ResetKey()
	{
		recorded = "";
	}
}
