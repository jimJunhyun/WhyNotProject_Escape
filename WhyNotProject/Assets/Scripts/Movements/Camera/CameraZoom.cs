using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private int normalFOV = 60;
    [SerializeField] private int zoomedFOV = 20;
    [Range(0, 1)]
    [SerializeField] private float lerpSpeed = 1.0f;
    [SerializeField] private KeyCode zoomKeyCode = KeyCode.Z;

    private bool isZoomed = false;
    private Camera cam;

	private void Start()
	{
		cam = GetComponent<Camera>();
	}

	private void Update()
    {
        Zoom();
        isZoomed = Input.GetKeyDown(zoomKeyCode) ? !isZoomed : isZoomed;
    }

    private void Zoom()
    {
        if (isZoomed == false)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, normalFOV, lerpSpeed);
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoomedFOV, lerpSpeed);
        }
    }
}
