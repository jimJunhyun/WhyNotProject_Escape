using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectManager : MonoBehaviour
{
    public static InspectManager Instance;
    Camera inspectCam;
    public float moveSpeed = 100f;
    
    public int InspectingNum = 0;

    public Image panel;
    public PlayerController pc;
    CharacterController cc;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        inspectCam = GetComponent<Camera>();
        panel.enabled = false;
        cc = pc.GetComponent<CharacterController>();
    }

	private void Update()
	{
        inspectCam.fieldOfView = Camera.main.fieldOfView;
        InspectingNum = Mathf.Max(0, InspectingNum);
	}

	public void ActiveInspect()
	{
        Debug.Log("조사 시작");
        panel.enabled = true;
        pc.enabled = false;
        cc.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
	}


    public void DisableInspect()
	{
        Debug.Log("조사 종료");
        panel.enabled = false;
        pc.enabled = true;
        cc.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
