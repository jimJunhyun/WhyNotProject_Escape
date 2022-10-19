using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightState : MonoBehaviour
{
	public enum LogicGates //2개 회로 연결이 필요한 회로만.
	{
		None = -1,

		AND,
		OR,
		NAND,
		NOR,
		XOR,
		XNOR,


		Max
	}
	public bool isLighted = false;
    public Material myMat;
	public LogicGates myLogic;
	public List<LightSwitch> connectedSignals;

	private void Awake()
	{
		myMat = GetComponent<MeshRenderer>().material;
	}

	private void Update()
	{
		CheckLight();
	}

	void CheckLight()
	{
		if(myLogic == LogicGates.AND)
		{
			if(connectedSignals[0].isOn && connectedSignals[1].isOn)
			{
				isLighted = true;
				myMat.EnableKeyword("_EMISSION");
			}
			else
			{
				isLighted = false;
				myMat.DisableKeyword("_EMISSION");
			}
		}
		else if(myLogic == LogicGates.OR)
		{
			if (connectedSignals[0].isOn || connectedSignals[1].isOn)
			{
				isLighted = true;
				myMat.EnableKeyword("_EMISSION");
			}
			else
			{
				isLighted = false;
				myMat.DisableKeyword("_EMISSION");
			}
		}
		else if (myLogic == LogicGates.NAND)
		{
			if (!(connectedSignals[0].isOn && connectedSignals[1].isOn))
			{
				isLighted = true;
				myMat.EnableKeyword("_EMISSION");
			}
			else
			{
				isLighted = false;
				myMat.DisableKeyword("_EMISSION");
			}
		}
		else if (myLogic == LogicGates.NOR)
		{
			if (!(connectedSignals[0].isOn || connectedSignals[1].isOn))
			{
				isLighted = true;
				myMat.EnableKeyword("_EMISSION");
			}
			else
			{
				isLighted = false;
				myMat.DisableKeyword("_EMISSION");
			}
		}
		else if (myLogic == LogicGates.XOR)
		{
			if (connectedSignals[0].isOn != connectedSignals[1].isOn)
			{
				isLighted = true;
				myMat.EnableKeyword("_EMISSION");
			}
			else
			{
				isLighted = false;
				myMat.DisableKeyword("_EMISSION");
			}
		}
		else if (myLogic == LogicGates.XNOR)
		{
			if (connectedSignals[0].isOn == connectedSignals[1].isOn)
			{
				isLighted = true;
				myMat.EnableKeyword("_EMISSION");
			}
			else
			{
				isLighted = false;
				myMat.DisableKeyword("_EMISSION");
			}
		}
	}
}
