using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GlowObjectCmd))]
public class Pressable : MonoBehaviour
{
    public PressManager manager;
    public string KeyInfo;

	public UnityEvent OnClicked;

	public float pressDelayTime = 0.5f;

	RaycastHit hit;
	Collider myCol;
	bool isPressing = false;

	private void Awake()
	{
		myCol = GetComponent<Collider>();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && HoldManager.Instance.MouseCursorDetect(out hit))
		{
			if (hit.collider == myCol && !isPressing)
			{
				StartCoroutine(DelayEnable());
				OnClicked.Invoke();
				manager.AddKey(KeyInfo);
				Debug.Log("!");
			}
		}
	}

	IEnumerator DelayEnable()
	{
		isPressing = true;
		yield return new WaitForSeconds(pressDelayTime);
		isPressing = false;
	}
}
