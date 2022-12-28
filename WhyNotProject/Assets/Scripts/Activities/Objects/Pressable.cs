using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GlowObjectCmd))]
public class Pressable : MonoBehaviour
{
    public PressKeyRecorder recorder;
    public string KeyInfo;

	public UnityEvent OnClicked;

	public float pressDelayTime = 0.5f;

	RaycastHit hit;
	List<Collider> myCol = new List<Collider>();
	bool isPressing = false;

	Animator anim;

	private void Awake()
	{
		anim = GetComponent<Animator>();
		GetComponents<Collider>(myCol);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && HoldManager.Instance.MouseCursorDetect(out hit))
		{
			Debug.Log("CLICKE");
			if (myCol.Exists(x => {return x == hit.collider;}) && !isPressing && !OptionUI.instance.IsPointerOverUIObject())
			{
				Debug.Log("PRESS");
				StartCoroutine(DelayEnable());
				OnClicked?.Invoke();
				recorder?.AddKey(KeyInfo);
			}
		}
	}

	IEnumerator DelayEnable()
	{
		isPressing = true;
		yield return new WaitForSeconds(pressDelayTime);
		isPressing = false;
		Debug.Log("REPRESSABLE");
	}
}
