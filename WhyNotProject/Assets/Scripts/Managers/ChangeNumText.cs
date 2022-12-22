using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeNumText : MonoBehaviour
{
    public PressKeyRecorder rec;
	TextMeshPro tmp;
	string curT = "";

	private void Awake()
	{
		tmp = GetComponent<TextMeshPro>();
		curT = "";
		tmp.text = "";
	}

	private void Update()
	{
		if(rec.recorded != curT)
		{
			curT = rec.recorded;
			tmp.text = curT;
		}
	}

}
