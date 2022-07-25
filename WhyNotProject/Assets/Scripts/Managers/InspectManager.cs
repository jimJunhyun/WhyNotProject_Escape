using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectManager : MonoBehaviour
{
    public static InspectManager Instance;
    Camera inspectCam;
    public float moveSpeed = 100f;
    [HideInInspector]
    public int InspectingNum = 0;

    public Image panel;
    public PlayerController pc;
    CharacterController cc;
    LockedCursorController lcctrl;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        inspectCam = GetComponent<Camera>();
        panel.enabled = false;
        cc = pc.GetComponent<CharacterController>();
        lcctrl = GameObject.Find("LockedCursor").GetComponent<LockedCursorController>();
    }

	private void Update()
	{
		if (InspectingNum > 0)
		{
            ActiveInspect();
		}
		else
		{
            DisableInspect();
		}
	}

	public void ActiveInspect()
	{

        panel.enabled = true;
        pc.enabled = false;
        cc.enabled = false;
        lcctrl.Esc = true;
	}


    public void DisableInspect()
	{
        panel.enabled = false;
        pc.enabled = true;
        cc.enabled = true;
        lcctrl.Esc = false;
    }
}
