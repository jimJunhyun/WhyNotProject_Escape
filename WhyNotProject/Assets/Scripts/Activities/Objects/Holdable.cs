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
	public string triggerName;
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
		if (!isReusable)
		{
			gameObject.SetActive(false);
			myGlow.Off();
		}
			
		myRig.useGravity = false;
		isPlaced = true;
		isHeld = false;
		transform.position = pos;
		transform.rotation = Quaternion.identity; //��ü���� �ٸ� ���� ���� �ʿ��� ��
	}
	void InteractionDetect()
	{
		if (HoldManager.Instance.MouseCursorDetect(out info))
		{
			if (Input.GetMouseButtonDown(0) && info.collider  == myCol)
			{
				if ((isReusable && isPlaced) || !isPlaced)
				{
					isHeld = true;
					isPlaced = false;
				}
				
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
		bufferArea = Mathf.Sqrt(Mathf.Log10( transform.localScale.magnitude) / 2) / 3;
		myRig = GetComponent<Rigidbody>();
		OnHeld = new UnityEvent();
		OnHeld.AddListener(Held);
		OnHeld.AddListener(myGlow.On);
	}

	#region ����Ƽ�⺻
	private void Awake()
	{
		Init();
	}
	private void Update()
	{
		InteractionDetect();
	}
	private void LateUpdate()
	{
		if (isHeld)
		{
			OnHeld.Invoke();
		}
		if(isHeld || isPlaced)
		{
			myRig.velocity = Vector3.zero;
			myRig.angularVelocity = Vector3.zero;
		}
	}
	#endregion
}
