using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockNum : MonoBehaviour
{
	public int num = 0;

	private void Update()
	{
		num = Mathf.RoundToInt((transform.eulerAngles.y - 18) / 36f);
		num = (num + 9) % 10;
	}
}
