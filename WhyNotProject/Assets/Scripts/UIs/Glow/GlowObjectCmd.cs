using UnityEngine;
using System.Collections.Generic;

public class GlowObjectCmd : MonoBehaviour
{
	public Color GlowColor;
	public float LerpFactor = 10;
	bool isFocused = false;
	Collider myCol;

	public Renderer[] Renderers
	{
		get;
		private set;
	}

	public Color CurrentColor
	{
		get { return _currentColor; }
	}

	private Color _currentColor;
	private Color _targetColor;

	public void On()
	{
		this.enabled = true;
	}

	public void Off()
	{
		_currentColor = Color.black;
		this.enabled = false;
	}

	void Start()
	{
		myCol = GetComponent<Collider>();
		Renderers = GetComponentsInChildren<Renderer>();
		GlowController.RegisterObject(this);
	}

	private void OnMouseEnter()
	{
		_targetColor = GlowColor;
		enabled = true;

	}

	private void OnMouseExit()
	{
		_targetColor = Color.black;
		enabled = true;

	}

	/// <summary>
	/// Update color, disable self if we reach our target color.
	/// </summary>
	private void Update()
	{
		HoldManager.Instance.MouseCursorDetect(out RaycastHit hit);
		isFocused = (hit.collider == myCol);


		if (isFocused)
		{
			_targetColor = GlowColor;
			
		}
		else
		{
			_targetColor = Color.black;
		}
		_currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * LerpFactor);
		

		//if (_currentColor.Equals(_targetColor))
		//{
		//	enabled = false;
		//}
	}
}
