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
	public float bufferArea;
    public UnityEvent OnHeld { get; set;}
    public bool isHeld { get; set;}
	public bool isPlaced { get; set;}
	[Tooltip("������ ���Ŀ��� �ٽ� �̾Ƽ� ����� �� �ִ°�?")]
	public bool isReusable = false;
	GlowObjectCmd myGlow;
	Collider myCol;
	Rigidbody myRig;
    public void Held()
	{
		HoldManager.Instance.currentHolding = this;
		isHeld = true;
		isPlaced = false;
		myRig.velocity = Vector2.zero;
		myRig.useGravity = false;
		transform.position = HoldManager.Instance.HoldPos;
		transform.rotation = Quaternion.identity;
		gameObject.layer = 2;
	}
    public void Fall()
	{
		HoldManager.Instance.currentHolding = null;
		isHeld = false;
		myRig.useGravity = true;
		gameObject.layer = 0;
	}
	public void Throw() 
	{
		Fall();
		myRig.AddForce(HoldManager.Instance.throwDirection * HoldManager.Instance.throwPower, ForceMode.Impulse);
	}
	public void Place(Vector3 pos)
	{
		myRig.useGravity = false;
		myRig.velocity = Vector2.zero;
		myGlow.Off();
		isPlaced = true;
		isHeld = false;
		transform.position = pos;
		transform.rotation = Quaternion.identity; //��ü���� �ٸ� ���� ���� �ʿ��� ��
		
		if (!isReusable)
		{
			OnHeld.RemoveListener(Held);
		}
	}
	void InteractionDetect()
	{
		if (HoldManager.Instance.MouseCursorDetect(out info))
		{
			if (Input.GetMouseButtonDown(0) && info.collider  == myCol)
			{
				isHeld = true;
			}
		}
		if (isHeld && Input.GetMouseButtonUp(0))
		{
			info = new RaycastHit();
			Fall();
		}
		else if (isHeld && Input.GetMouseButtonDown(1))
		{
			info = new RaycastHit();
			Throw();
		}
	}
	void Init()
	{
		myGlow = GetComponent<GlowObjectCmd>();
		myCol = GetComponent<Collider>();
		bufferArea = transform.localScale.magnitude / 2f;
		myRig = GetComponent<Rigidbody>();
		OnHeld = new UnityEvent();
		OnHeld.AddListener(Held);
	}

	#region ����Ƽ�⺻
	private void Awake()
	{
		Init();
	}
	private void Update()
	{
		if (!isPlaced)
		{
			InteractionDetect();
		}
		
	}
	private void LateUpdate()
	{
		if (isHeld)
		{
			OnHeld.Invoke();
		}
	}
	#endregion
}
