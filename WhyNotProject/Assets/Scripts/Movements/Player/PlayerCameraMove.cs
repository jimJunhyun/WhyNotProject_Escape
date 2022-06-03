using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMove : MonoBehaviour
{
    public float cameraSensitivity = 5;

    [SerializeField]
    private float cameraRotationLimit;
    private float CamRotX = 0;
    private float CamRotY = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float xMouse = Input.GetAxisRaw("Mouse X");
        float yMouse = Input.GetAxisRaw("Mouse Y");

        CamRotX -= cameraSensitivity * 100 * yMouse * Time.deltaTime;
        CamRotY += cameraSensitivity * 100 * xMouse * Time.deltaTime;

        CamRotX = Mathf.Clamp(CamRotX, -80, 80);

        transform.rotation = Quaternion.Euler(CamRotX, CamRotY, 0);
    }
}
