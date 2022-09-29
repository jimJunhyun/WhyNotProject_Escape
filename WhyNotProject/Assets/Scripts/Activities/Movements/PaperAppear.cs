using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperAppear : MonoBehaviour
{
	public Vector3 dPos;
	Vector3 initpos;
    public void SlideOut(float t)
	{
		StartCoroutine(SmoothLerp(t));
	}
	IEnumerator SmoothLerp(float t)
	{
		float curTime = 0;
		initpos = transform.position;
		while(curTime <= t)
		{
			curTime += Time.deltaTime;
			transform.position = Vector3.Lerp(initpos, initpos+ dPos, curTime / t);
			yield return null;
		}
	}
}
