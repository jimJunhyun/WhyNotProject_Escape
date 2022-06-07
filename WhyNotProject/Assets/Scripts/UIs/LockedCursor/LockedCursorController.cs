using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedCursorController : MonoBehaviour
{
    bool move = false;
    RectTransform rectTrans;

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            move = !move;
        }

        Cursor.lockState = move ? CursorLockMode.None : CursorLockMode.Locked;

        if (move == false)
        {
            rectTrans.transform.position = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        }
        else if (move == true)
        {
            rectTrans.transform.position = Input.mousePosition;
        }
    }
}
