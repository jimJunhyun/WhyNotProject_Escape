using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PostWeight : MonoBehaviour
{
	public int maxWeight = 10;
	public int objCount = 0;
	[SerializeField] private Vector3 basePosition;
	[SerializeField] private Vector3 targetPosition;

	[Header("ColliderSettings")]
	[SerializeField] private int currentWeight = 0;
	[SerializeField] private Vector3 boxCastSize;
	[SerializeField] private Vector3 boxPosition;
	[SerializeField] private int coinLayer;

	[Header("MovementSetting")]
	[SerializeField] private Ease moveEase;
	[SerializeField] private float moveTime;

	RaycastHit[] hits;
	RaycastHit[] currentHits;
	private Vector3 moveAmount;

	private void Awake()
	{
		basePosition = transform.position;
		moveAmount = targetPosition - transform.position;

		coinLayer = 1 << LayerMask.NameToLayer("Holdable");
	}

	private void FixedUpdate()
	{
		if (objCount != CastCollider()) // 저장된 오브젝트의 수와 범위 내의 오브젝트의 수가 다를 때
		{
			ColliderCast();
		}
	}

	private int CastCollider() //범위 내의 오브젝트를 탐색 및 탐색한 오브젝트의 개수를 반환
	{
		hits = Physics.BoxCastAll(transform.position + boxPosition, boxCastSize * 0.5f, Vector3.up, Quaternion.identity, 1f, coinLayer);

		return hits.Length;
	}

	private void ColliderCast() //현재 범위 내의 오브젝트 저장
	{
		if (currentHits?.Length > 0)
		{
			foreach (RaycastHit obj in currentHits)
			{
				obj.transform.SetParent(null);
			}
		}

		currentHits = hits;

		print("Cast");
		objCount = CastCollider();

		currentWeight = 0;

		foreach (RaycastHit col in hits)
		{
			col.transform.SetParent(transform);
			currentWeight += col.transform.GetComponent<Holdable>().objWeight;
			currentWeight = Mathf.Clamp(currentWeight, 0, maxWeight);
		}

		transform.DOMoveY(basePosition.y + moveAmount.y * (float)(currentWeight / (float)maxWeight), moveTime).SetEase(moveEase, 1f);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireCube(transform.position + boxPosition, boxCastSize);
		Gizmos.DrawLine(transform.position, transform.position + boxPosition);
		Gizmos.color = Color.white;
	}
}
