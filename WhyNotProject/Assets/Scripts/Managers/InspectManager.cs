using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectManager : MonoBehaviour
{
    public static InspectManager Instance;
    Camera inspectCam;
    public float moveSpeed = 100f;

    public Image panel;
    public PlayerCameraMove camMove;
    public PlayerController pc;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        inspectCam = GetComponent<Camera>();
        panel.enabled = false;
    }

    public void ActiveInspect()
	{
        panel.enabled = true;
        camMove.enabled = false;
        pc.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
	}
    public void DisableInspect()
	{
        panel.enabled = false;
        camMove.enabled = true;
        pc.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}