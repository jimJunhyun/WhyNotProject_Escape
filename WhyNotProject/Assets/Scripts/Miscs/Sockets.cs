using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sockets : MonoBehaviour
{
	public List<Holdable> keys = new List<Holdable>(); //소켓에 들어갈 수 있는 물체들
	public UnityEvent OnMatched;
	public bool activated = true;

	Holdable keyInfo;

	List<MeshRenderer> animRenderers = new List<MeshRenderer>();
	private void Awake()
	{
		GetComponentsInChildren(animRenderers);
	}

	private void OnTriggerStay(Collider collision)
	{
		if(!collision.gameObject.TryGetComponent(out keyInfo))
		{
			Debug.Log(collision.name + " detected at " + collision.ClosestPointOnBounds(transform.position));
		}
		else if (keys.Contains(keyInfo) && !keyInfo.isHeld && !keyInfo.isPlaced && activated)
		{
			keyInfo.Place(transform.position);
			OnMatched.Invoke();
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