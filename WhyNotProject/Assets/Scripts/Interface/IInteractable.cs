using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInteractable
{
	public UnityEvent OnHeld { get; set;}
	public bool isHeld { get; set;}
	public void Held(); //����� �� ����
	public void Fall(); //�տ��� ��������
	public void Throw();
	public void Place(); //��ġ�� �� ����
}
