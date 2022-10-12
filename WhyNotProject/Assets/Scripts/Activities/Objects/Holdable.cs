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
	public float bufferArea;
	
    public UnityEvent OnHeld { get; set;}
    public bool isHeld { get; set;}
	public bool isPlaced { get; set;}
	public Vector3 holdRot;
	[Tooltip("놓여진 이후에도 다시 뽑아서 사용할 수 있는가?")]
	public bool isReusable = false;
	public Vector3 placedRot;
	public float animLen;


	GlowObjectCmd myGlow;
	Collider myCol;
	Rigidbody myRig;
	Renderer myRen;
	PlayerController player;
    public void Held()
	{
		HoldManager.Instance.currentHolding = this;
		myRig.useGravity = false;
		transform.position = HoldManager.Instance.HoldPos;
		transform.LookAt(player.transform);
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
		myRen.enabled = false;
		myCol.enabled = false;
		StartCoroutine(DelayPlace(pos));
	}
	void InteractionDetect()
	{
		if (HoldManager.Instance.MouseCursorDetect(out info))
		{
			if (Input.GetMouseButtonDown(0) && info.collider  == myCol)
			{
				if (((isReusable && isPlaced) || !isPlaced) && !OptionUI.instance.IsPointerOverUIObject())
				{
					isHeld = true;
					isPlaced = false;
				}
				
			}
		}
		if (isHeld && Input.GetMouseButtonUp(0) && !OptionUI.instance.IsPointerOverUIObject())
		{
			info = new RaycastHit();
			Fall();
		}
		else if (isHeld && Input.GetMouseButtonDown(1) && !OptionUI.instance.IsPointerOverUIObject())
		{
			info = new RaycastHit();
			Throw();
		}
	}
	void Init()
	{
		myGlow = GetComponent<GlowObjectCmd>();
		myCol = GetComponent<Collider>();
		myRen = GetComponent<Renderer>();
		player = FindObjectOfType<PlayerController>();
		if(bufferArea == 0)
		{
			bufferArea = Mathf.Sqrt(Mathf.Abs(Mathf.Log10(transform.localScale.magnitude) / 2)) / 3;

		}
		
		myRig = GetComponent<Rigidbody>();
		OnHeld = new UnityEvent();
		OnHeld.AddListener(Held);
		OnHeld.AddListener(myGlow.On);
	}

	IEnumerator DelayPlace(Vector3 pos)
	{
		isPlaced = true;
		yield return new WaitForSeconds(animLen);
		myRig.useGravity = false;
		
		isHeld = false;
		transform.position = pos;
		transform.eulerAngles = placedRot;
		myCol.enabled = true;
		myRen.enabled = true;
		if (!isReusable)
		{
			gameObject.SetActive(false);
			myGlow.Off();
		}
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
