using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInteractable
{
	public UnityEvent OnHeld { get; set;}
	public bool isHeld { get; set;}
	public bool isPlaced { get; set;} //놓일 수 있는 위치에 놓여있는가?
	public void Held(); //들렸을 때 행위
	public void Fall(); //손에서 놓았을때
	public void Throw();
	public void Place(); //배치할 때 행위

}
