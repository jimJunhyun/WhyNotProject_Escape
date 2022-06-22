using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertCoin : MonoBehaviour
{
	Coroutine c;
    public void startInsert()
	{
		c = StartCoroutine(translate());
	}

	public void stopInsert()
	{
		StopCoroutine(c);
	}

	IEnumerator translate()
	{
		while (true)
		{
			transform.Translate(Vector3.right * Time.deltaTime);
			yield return null;
		}
	}
}
