using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedCursorController : MonoBehaviour
{
    private bool esc = false;

    public  bool Esc
    {
        get { return esc; }
        set { esc = value; }
    }

    private RectTransform rectTrans;

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Cursor.lockState = OptionUI.instance.optionOpened || InspectManager.Instance.InspectingNum >= 1 ? CursorLockMode.None : CursorLockMode.Locked;

        if (!(OptionUI.instance.optionOpened || InspectManager.Instance.InspectingNum >= 1))
        {
            Debug.Log("화면 고정 안 됨");
            rectTrans.transform.position = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        }
        else
        {
            Debug.Log("화면 고정 됨");
            rectTrans.transform.position = Input.mousePosition;
        }
    }
}
