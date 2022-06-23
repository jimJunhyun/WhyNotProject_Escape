using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectManager : MonoBehaviour
{
    public static InspectManager Instance;
    public float moveSpeed = 100f;

    public Image panel;
    public PlayerController pc;
    CharacterController cc;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        panel.enabled = false;
        cc = pc.GetComponent<CharacterController>();
    }

    public void ActiveInspect()
	{
        panel.enabled = true;
        pc.enabled = false;
        pc.cursor.enabled = false;
        cc.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
	}
    public void DisableInspect()
	{
        panel.enabled = false;
        pc.enabled = true;
        pc.cursor.enabled = true;
        cc.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
