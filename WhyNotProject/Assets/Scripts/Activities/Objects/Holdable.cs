using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GlowObjectCmd))]
public class Holdable : MonoBehaviour, IInteractable
{
	RaycastHit info;
	Ray screenRay;
    public UnityEvent OnHeld { get; set;}
    public bool isHeld { get; set;}
	Rigidbody myRig;
    public void Held()
	{
		myRig.velocity = Vector2.zero;
		transform.position = HoldObject.HoldPos;
	}
    public void Fall()
	{

	}
	public void Throw() 
	{
		
	}
	private void Awake()
	{
		myRig = GetComponent<Rigidbody>();
		OnHeld = new UnityEvent();
		OnHeld.AddListener(Held);
	}
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(screenRay, out info))
			{
				if(info.collider == gameObject.GetComponent<Collider>())
				{
					isHeld = true;
				}
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			info = new RaycastHit();
			isHeld = false;
		}
	}
	private void LateUpdate()
	{
		if (isHeld)
		{
			OnHeld.Invoke();
		}
		else
		{
			Fall();
		}
	}
}
