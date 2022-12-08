using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System.Linq;

public class PostWeight : MonoBehaviour
{
	public int maxWeight = 10;
	public int objCount = 0;

	[Header("Collider Settings")]
	[SerializeField] private int currentWeight = 0;
	[SerializeField] private Vector3 boxCastSize;
	[SerializeField] private Vector3 boxPosition;
	[SerializeField] private int coinLayer;

	private RaycastHit[] hits;
	private RaycastHit[] currentHits;

	[Header("Movement Setting")]
	[SerializeField] private Ease moveEase;
	[SerializeField] private float moveTime;

	public UnityEvent OnTriggered;

	private void Awake()
	{
		coinLayer = 1 << LayerMask.NameToLayer("Holdable");
	}

	private void FixedUpdate()
	{
		// ����� ������Ʈ�� ���� ������Ʈ�� �ٸ� �� ������Ʈ�� �ٽ� Ž��
		if (objCount != CastCollider())
		{
			ColliderCast();
		}
	}

	/// <summary>
	/// ���� ���� ������Ʈ�� Ž���ϴ� �Լ�
	/// </summary>
	/// <returns>Ž���� ������Ʈ�� ����</returns>
	private int CastCollider()
	{
		hits = Physics.BoxCastAll(transform.position + boxPosition, boxCastSize * 0.5f, Vector3.up, Quaternion.identity, 0f, coinLayer);

		return hits.Length;
	}
	/// <summary>
	/// ������Ʈ�� Ž���Ͽ� �����ϴ� �Լ�
	/// </summary>
	private void ColliderCast()
	{
		if (currentHits?.Length > 0)
		{
			foreach (RaycastHit obj in currentHits)
			{
				obj.transform.SetParent(null);
			}
		}

		currentHits = hits;

		objCount = CastCollider();
		currentWeight = 0;

		foreach (RaycastHit hit in hits)
		{
			hit.transform.SetParent(transform);
			currentWeight += hit.transform.GetComponent<Holdable>().objWeight;
			currentWeight = Mathf.Clamp(currentWeight, 0, maxWeight);
		}

		if (currentWeight >= maxWeight)
		{
			OnWeightMax();
		}
	}

	/// �ִ� ���Կ� �������� �� �̺�Ʈ�� ȣ���ϴ� �Լ�
	private void OnWeightMax()
	{
		OnTriggered?.Invoke();
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireCube(transform.position + boxPosition, boxCastSize);
		Gizmos.DrawLine(transform.position, transform.position + boxPosition);
		Gizmos.color = Color.white;
	}
}
