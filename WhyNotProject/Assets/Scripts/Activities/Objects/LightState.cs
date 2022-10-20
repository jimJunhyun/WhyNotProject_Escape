using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightState : MonoBehaviour
{
	public enum LogicGates //2�� ȸ�� ������ �ʿ��� ȸ�θ�.
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
	public List<int> connectedSignals;

	public  bool reversed = false;
	int gap;

	private void Awake()
	{
		myMat = GetComponent<MeshRenderer>().material;
		gap = connectedSignals[1] - connectedSignals[0];
	}

	private void Update()
	{
		CheckLight();
	}

	public void Reverse()
	{
		if (reversed)
		{
			connectedSignals[1] = connectedSignals[0] + gap;
			reversed = false;
		}
		else
		{
			connectedSignals[1] = connectedSignals[0] - gap;
			reversed = true;
		}
		
		if(connectedSignals[1] < 0)
		{
			connectedSignals[1] += 5;
		}
		if(connectedSignals[1] > 4)
		{
			connectedSignals[1] -= 5;
		}
	}

	void CheckLight()
	{
		if(myLogic == LogicGates.AND)
		{
			if(LightRule.instance.Switches[connectedSignals[0]].isOn && LightRule.instance.Switches[connectedSignals[1]].isOn)
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
			if (LightRule.instance.Switches[connectedSignals[0]].isOn || LightRule.instance.Switches[connectedSignals[1]].isOn)
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
			if (!(LightRule.instance.Switches[connectedSignals[0]].isOn && LightRule.instance.Switches[connectedSignals[1]].isOn))
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
			if (!(LightRule.instance.Switches[connectedSignals[0]].isOn || LightRule.instance.Switches[connectedSignals[1]].isOn))
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
			if (LightRule.instance.Switches[connectedSignals[0]].isOn != LightRule.instance.Switches[connectedSignals[1]].isOn)
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
			if (LightRule.instance.Switches[connectedSignals[0]].isOn == LightRule.instance.Switches[connectedSignals[1]].isOn)
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
