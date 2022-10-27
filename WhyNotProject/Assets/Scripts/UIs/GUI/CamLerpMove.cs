using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLerpMove : MonoBehaviour
{
	public Transform LookingAt;
    public List<Transform> positions;
    public float transGap;
    public float transDuration;

	int idx = 0;

	private void Awake()
	{
		StartCoroutine(Transition());
	}

	private void Update()
	{
		transform.LookAt(LookingAt);
	}

	IEnumerator Transition()
	{
		while (true)
		{
			yield return new WaitForSeconds(transGap);
			transform.position = positions[idx].position;
			++idx;
			if (idx >= positions.Count)
			{
				idx = 0;
			}
			
		}
	}
}
