using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private int normalFOV = 60;
    [SerializeField] private int zoomedFOV = 20;
    [SerializeField] private float lerpSpeed = 1.0f;
    [SerializeField] private KeyCode zoomKeyCode = KeyCode.Z;

    private bool isZoomed = false;

    private void Update()
    {
        Zoom();

        if (Input.GetKeyDown(zoomKeyCode))
        {
            isZoomed = !isZoomed;
        }
    }

    private void Zoom()
    {
        if (isZoomed == false)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normalFOV, lerpSpeed * Time.deltaTime);
        }
        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoomedFOV, lerpSpeed * Time.deltaTime);
        }
    }
}
