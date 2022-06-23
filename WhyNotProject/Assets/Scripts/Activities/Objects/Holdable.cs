using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 들 수 있는 오브젝트에 붙어있는 스크립트이다.
/// 들고 떨어뜨리기, 투척하고 배치하기가 가능하다.
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
	[Tooltip("놓여진 이후에도 다시 뽑아서 사용할 수 있는가?")]
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
		transform.rotation = Quaternion.identity; //물체별로 다른 각도 조절 필요할 듯
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

	#region 유니티기본
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
