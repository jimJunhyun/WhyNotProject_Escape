using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sockets : MonoBehaviour
{
	public List<Holdable> keys = new List<Holdable>(); //소켓에 들어갈 수 있는 물체들
	public UnityEvent OnMatched;
	public UnityEvent OnExit;
	public bool activated = true;

	Holdable keyInfo;

	List<MeshRenderer> animRenderers = new List<MeshRenderer>();
	private void Awake()
	{
		GetComponentsInChildren(animRenderers);
	}

	private void OnTriggerStay(Collider collision)
	{

		if ((keyInfo= collision.GetComponent<Holdable>())&& keys.Contains(keyInfo) && !keyInfo.isHeld && !keyInfo.isPlaced && activated)
		{
			keyInfo.Place(transform.position);
			OnMatched.Invoke();
			Debug.Log("?????");
		}
	}
	private void OnTriggerExit(Collider other)
	{
		Debug.Log("EXIT");
		if (keys.Contains(keyInfo) && activated && keyInfo.isHeld )
		{
			OnExit.Invoke();
			keyInfo = null;
			Debug.Log("!!!0");
		}
	}

	public void Activate()
	{
		activated = true;
	}

	public void DisActivate()
	{
		activated = false;
		for (int i = 0; i < animRenderers.Count; i++)
		{
			animRenderers[i].enabled = false;
		}
	}

}