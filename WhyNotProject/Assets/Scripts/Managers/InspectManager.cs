using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectManager : MonoBehaviour
{
    public static InspectManager Instance;
    public float moveSpeed = 100f;
    Camera myCam;
    public Image panel;
    public PlayerController pc;
    CharacterController cc;
    [HideInInspector]
    public bool inspecting = false;
    // Start is called before the first frame update
    void Awake()
    {
        myCam = GetComponent<Camera>();
        Instance = this;
        panel.enabled = false;
        cc = pc.GetComponent<CharacterController>();
    }

	private void Update()
	{
		myCam.fieldOfView = Camera.main.fieldOfView;
	}

	public void ActiveInspect()
	{
        inspecting = true;
        panel.enabled = true;
        pc.enabled = false;
        pc.cursor.enabled = false;
        cc.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
	}
    public void DisableInspect()
	{
        inspecting = false;
        panel.enabled = false;
        pc.enabled = true;
        pc.cursor.enabled = true;
        cc.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
