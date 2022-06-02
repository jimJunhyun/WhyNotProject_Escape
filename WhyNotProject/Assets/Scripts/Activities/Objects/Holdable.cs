using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// �� �� �ִ� ������Ʈ�� �پ��ִ� ��ũ��Ʈ�̴�.
/// ��� ����߸���, ��ô�ϰ� ��ġ�ϱⰡ �����ϴ�.
/// </summary>
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
		myRig.useGravity = false;
		transform.position = HoldManager.Instance.HoldPos;
		transform.rotation = Quaternion.identity;
		gameObject.layer = 2;
	}
    public void Fall()
	{
		isHeld = false;
		myRig.useGravity = true;
		gameObject.layer = 0;
	}
	public void Throw() 
	{
		Fall();
		myRig.AddForce(transform.forward * HoldManager.Instance.throwPower, ForceMode.Impulse);
	}
	public void Place()
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
		else if (isHeld && Input.GetMouseButtonUp(0))
		{
			info = new RaycastHit();
			Fall();
		}
		else if(isHeld && Input.GetMouseButtonDown(1))
		{
			info = new RaycastHit();
			Throw();
		}
	}
	private void LateUpdate()
	{
		if (isHeld)
		{
			OnHeld.Invoke();
		}
	}
}
