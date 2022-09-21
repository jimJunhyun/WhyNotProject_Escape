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
        Cursor.lockState = OptionUI.instance.optionOpened ? CursorLockMode.None : CursorLockMode.Locked;

        if (!OptionUI.instance.optionOpened)
        {
            rectTrans.transform.position = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        }
        else
        {
            rectTrans.transform.position = Input.mousePosition;
        }
    }
}
